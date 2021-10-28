using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medit1.Models;
using Medit1.Models.ViewModels;
using Medit1.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Medit1.Controllers
{
    
    public class CruisesController : Controller
    {
        private readonly Medit1DbContext _context;

        public CruisesController(Medit1DbContext context)
        {
            _context = context;
        }

        // GET: Cruises
        public async Task<IActionResult> Index(int filterId =-1,string portname = "")
        {
            ViewBag.Portname = portname;
            ViewBag.FilterId = filterId;
            var viewModels = new IndexCruiseViewModel
            {
                Cruises = new List<Cruise>(),
                TypeCruises = await _context.TypeCruises.ToListAsync()
            };

            var ports = await _context.Ports.ToListAsync();
            IQueryable<Cruise> cruisesQueryable = _context.Cruises
                .Include(c => c.PortDepart)
                .Include(c => c.ArrivalPort)
                .Include(c => c.Boat)
                .Include(c => c.Images)
                .Include(c => c.TransitPorts).ThenInclude(t=>t.Port); 
            if (! string.IsNullOrEmpty(portname))
            {
                cruisesQueryable = cruisesQueryable.Where(c =>
                    c.PortDepart.Name.Contains(portname) ||
                    c.ArrivalPort.Name.Contains(portname) ||
                    c.TransitPorts.Any(t => t.Port.Name.Contains(portname)));
            }

            var cruises = filterId switch
            {
                -1 => await cruisesQueryable.ToListAsync(),
                -2 => await cruisesQueryable.Where(c => c.AdultOnly).ToListAsync(),
                _ => await cruisesQueryable.Where(c => c.TypeCruise.TypeCruiseId == filterId).ToListAsync(),
            };
            foreach (var cruise in from cruise in cruises
                where cruise.DateDepart > DateTime.Now && cruise.DateArrivee > DateTime.Now
                let nbReservation = _context.ParticipantReservations.Include(p => p.Reservation).ThenInclude(p => p.Cruise)
                    .Where(p => p.Reservation.Cruise.CruiseId == cruise.CruiseId).ToList()
                .Count let nbTotalPlace = cruise.Boat.NbConvives let placeDispo = nbTotalPlace - nbReservation where placeDispo > 0 select cruise)
            {
                cruise.DistanceTotal = DistanceCalculator.GetDistance(cruise.PortDepart, cruise.ArrivalPort, cruise.TransitPorts);
                viewModels.Cruises.Add(cruise);
            }


            return View(viewModels);
        }

        // GET: Cruises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cruises = await _context.Cruises
                .FirstOrDefaultAsync(m => m.CruiseId == id);
            if (cruises == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var cruise = await _context.Cruises.Include(c => c.PortDepart)
                .Include(m=>m.ArrivalPort)
                .Include(m=>m.TypeCruise)
                .Include(m=>m.Boat)
                .Include(m=>m.Images)
                .Include(m=>m.Commodites).ThenInclude(co=>co.Commodite)
                .Include(m=>m.TransitPorts).ThenInclude(po=>po.Port)
                .FirstOrDefaultAsync(m=>m.CruiseId == id);
            cruise.DistanceTotal = DistanceCalculator.GetDistance(cruise.PortDepart, cruise.ArrivalPort, cruise.TransitPorts);

            var allReservations = await _context.ParticipantReservations.Include(p => p.Reservation).ThenInclude(p => p.Cruise)
                .Where(p => p.Reservation.Cruise.CruiseId == cruise.CruiseId).ToListAsync();

            var nbReservation = allReservations.Count;
            var nbTotalPlace = cruise.Boat.NbConvives;
            var placeDispo = nbTotalPlace - nbReservation;


            var vm = new DetailCruiseViewModel(){Cruise = cruise,PlaceDisponible = placeDispo, PlaceTotal = nbTotalPlace};
            
            return View(vm);
        }
        [Authorize(Roles = "Director")]
        // GET: Cruises/Create
        public async Task<IActionResult> Create()
        {
            var model = new CreateCruiseViewModel()
            {
                Boats = await _context.Boats.ToListAsync(),
                Ports =await _context.Ports.ToListAsync(),
                TypeCruises =await _context.TypeCruises.ToListAsync(),
                Commodites = await _context.Commodites.ToListAsync()
            };
            return View(model);
        }
        [Authorize(Roles = "Director")]
        // POST: Cruises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCruiseViewModel createCruiseViewModel)
        {
            createCruiseViewModel.Boats = await _context.Boats.ToListAsync();
            createCruiseViewModel.Ports = await _context.Ports.ToListAsync();
            createCruiseViewModel.TypeCruises = await _context.TypeCruises.ToListAsync();
            createCruiseViewModel.Commodites = await _context.Commodites.ToListAsync();

            if (!ModelState.IsValid) return View(createCruiseViewModel);
            var cruise = createCruiseViewModel.Cruise;
            var boat = await _context.Boats.FindAsync(createCruiseViewModel.BoatId);
            var departPort = await _context.Ports.FindAsync(createCruiseViewModel.DeparturePortId);
            var arrivalPort = await _context.Ports.FindAsync(createCruiseViewModel.ArrivalPortId);
            var typeCruise = await _context.TypeCruises.FindAsync(createCruiseViewModel.TypeCruiseId);
            if (boat == null && departPort==null && arrivalPort == null && typeCruise==null) return View(createCruiseViewModel);
            cruise.Boat = boat;
            cruise.PortDepart = departPort;
            cruise.ArrivalPort = arrivalPort;
            cruise.TypeCruise = typeCruise;
            cruise.AdultOnly = typeCruise.AdultOnly;
            _context.Add(cruise);
            await _context.SaveChangesAsync();

            await AddImage(createCruiseViewModel.File, cruise);
            await AddTransitPort(createCruiseViewModel.TransitPortId, cruise);
            await AddCommoditeForCruise(createCruiseViewModel.CommoditesIds, cruise);

            return RedirectToAction("Index", "Administration");
        }

        private async Task AddImage(ICollection<IFormFile> images, Cruise cruise)
        {
            if (images != null && images.Count != 0)
            {
                cruise.Images = new List<Image>();
                foreach (var photoFile in images)
                {
                    var image =await ImageAdder.AddImage(photoFile, cruise);
                    //
                    cruise.Images.Add(image);
                    _context.Add(image);
                    await _context.SaveChangesAsync();
                }
            }
        }

        private async Task AddTransitPort(ICollection<int> transitPortIds, Cruise cruise)
        {
            var transit = new List<CruisePort>();
            if (transitPortIds != null) 
                foreach (var transitPortId in transitPortIds)
                {
                    var port = await _context.Ports.FindAsync(transitPortId);
                    if (port != null)
                    {
                        var cruiseport = new CruisePort() { Cruise = cruise, Port = port };
                        transit.Add(cruiseport);
                        await _context.CruisePorts.AddAsync(cruiseport);
                        await _context.SaveChangesAsync();
                    }
                }
            cruise.TransitPorts = transit;
        }

        private async Task AddCommoditeForCruise(ICollection<int> commoditeIds, Cruise cruise)
        {
            var commodites = new List<CruiseCommodite>();
            if (commoditeIds != null) foreach (var commoditeid in commoditeIds)
            {
                var commodite = await _context.Commodites.FindAsync(commoditeid);
                if (commodite != null)
                {
                    var com = new CruiseCommodite() { Cruise = cruise, Commodite = commodite };
                    commodites.Add(com);
                    await _context.CruiseCommodites.AddAsync(com);
                    await _context.SaveChangesAsync();
                }
            }

            cruise.Commodites = commodites;
        }

        [Produces("application/json")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchPort()
        {
            var term = HttpContext.Request.Query["portname"].ToString();
            var list = await _context.Ports.Where(p => p.Name.Contains(term)).Select(p => p.Name).ToListAsync();
            return Ok(list);
        }

        [Produces("application/json")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AskDistance()
        {
            var portDepartId =int.Parse(HttpContext.Request.Query["portDepartId"].ToString());
            var portArrivalId = int.Parse(HttpContext.Request.Query["portArrivalId"].ToString());
            var portsTransitId = HttpContext.Request.Query["portsTransitId"].ToArray();
            var departPort = await _context.Ports.FindAsync(portDepartId);
            var arrivalPort = await _context.Ports.FindAsync(portArrivalId);
            var transitPort = new List<Port>();
            if (departPort != null && arrivalPort != null)
            {
                foreach (var portIds in portsTransitId)
                {
                    var portId = int.Parse(portIds);
                    var p= await _context.Ports.FindAsync(portId);
                    if(p!=null) transitPort.Add(p);
                }

                double distance = DistanceCalculator.GetDistance(departPort, arrivalPort, transitPort);

                return Ok( distance );
            }

            return Ok(0);
        }

     
        [Authorize(Roles = "Director")]
        // GET: Cruises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cruise = await _context.Cruises
                .FirstOrDefaultAsync(m => m.CruiseId == id);
            if (cruise == null)
            {
                return NotFound();
            }

            return View(cruise);
        }

        // POST: Cruises/Delete/5
        [Authorize(Roles = "Director")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cruise = await _context.Cruises.FindAsync(id);
            if (cruise == null) return RedirectToAction("Index", "Administration");
            _context.Cruises.Remove(cruise);
            var images = await _context.Image.Where(i => i.Cruise.CruiseId == id).ToListAsync();
            _context.Image.RemoveRange(images);
            _context.CruiseCommodites.RemoveRange(await _context.CruiseCommodites.Where(i => i.Cruise.CruiseId == id).ToListAsync());
            _context.CruisePorts.RemoveRange(await _context.CruisePorts.Where(i => i.Cruise.CruiseId == id).ToListAsync());
            var reservations = await _context.Reservations.Where(i => i.Cruise.CruiseId == id).ToListAsync();
            _context.Reservations.RemoveRange(reservations);
            
            await _context.SaveChangesAsync();
            foreach (var path in images.Select(image => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/cruises", image.Path)).Where(System.IO.File.Exists))
            {
                System.IO.File.Delete(path);
            }

            return RedirectToAction("Index", "Administration");
        }


        
    }
}
