using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medit1.Models;
using Medit1.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Medit1.Controllers
{
    [Authorize]
    public class PortsController : Controller
    {
        private readonly Medit1DbContext _context;

        public PortsController(Medit1DbContext context)
        {
            _context = context;
        }

        


        // GET: Ports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortViewModel portVm)
        {
            if (ModelState.IsValid)
            {
                var port = new Port()
                {
                    Latitude = float.Parse(portVm.Latitude),
                    Longitude = float.Parse(portVm.Longitude),
                    Name = portVm.Name
                };
                _context.Add(port);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Administration");
            }
            return View(portVm);
        }

        // GET: Ports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var port = await _context.Ports.FindAsync(id);
            if (port == null)
            {
                return NotFound();
            }

            var portVm = new PortViewModel()
            {
                Latitude = port.Latitude.ToString(CultureInfo.CurrentCulture),
                Longitude = port.Longitude.ToString(CultureInfo.CurrentCulture),
                Name = port.Name,
                PortId = port.PortId
            };

            return View(portVm);
        }

        // POST: Ports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PortViewModel portViewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var port = new Port()
                    {
                        Latitude = float.Parse(portViewModel.Latitude),
                        Longitude = float.Parse(portViewModel.Longitude),
                        Name = portViewModel.Name,
                        PortId = portViewModel.PortId
                    };

                    _context.Update(port);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortExists(portViewModel.PortId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Administration");
            }
            return View(portViewModel);
        }

        // GET: Ports/Delete/5
        public async Task<IActionResult> Delete(int? id, [AllowNull]ICollection<string> cruisesName)
        {
            if (id == null)
            {
                return NotFound();
            }

            var port = await _context.Ports
                .FirstOrDefaultAsync(m => m.PortId == id);
            if (port == null)
            {
                return NotFound();
            }
            var portvm = new DeletePortViewModel()
            {
                CruisesName = cruisesName,
                Latitude = port.Latitude,
                Longitude = port.Longitude,
                Name = port.Name,
                PortId = port.PortId
            };


            return View(portvm);
        }

        // POST: Ports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var port = await _context.Ports.FindAsync(id);
            if (port == null) return NotFound();
            var cruises = await _context.Cruises.Where(c => c.PortDepart.PortId == id || c.ArrivalPort.PortId == id).ToListAsync();
            var cruisesTrans = await _context.Cruises.Include(c => c.TransitPorts).Where(c => c.TransitPorts.Any(t => t.PortId == id))
                .ToListAsync();
            var enumerable = cruises.Concat(cruisesTrans).ToList();
            if (enumerable.Count==0)
            {
                _context.Ports.Remove(port);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Administration");
            }
            else
            {
                var cruisesName = new HashSet<string>();
                foreach (var cruise in enumerable)
                {
                    cruisesName.Add(cruise.Name);
                }

                return RedirectToAction("Delete", new { id = id ,cruisesName=cruisesName});

            }

        }

        private bool PortExists(int id)
        {
            return _context.Ports.Any(e => e.PortId == id);
        }
    }
}
