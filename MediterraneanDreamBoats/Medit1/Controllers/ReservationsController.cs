using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medit1.Models;
using Medit1.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Medit1.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly Medit1DbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;


        public ReservationsController(Medit1DbContext context, SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Authorize(Roles = "Director")]
        public async Task<IActionResult> AllReservationForCruise(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var cruise = await _context.Cruises.FirstAsync(c => c.CruiseId == id);
            var reservations = await _context.ParticipantReservations
                .Include(p=>p.Reservation)
                .Include(p=>p.Participant)
                .Where(r => r.Reservation.Cruise.CruiseId == cruise.CruiseId)
                .ToListAsync();
            var administrationReservationViewModel = new AdministrationReservationViewModel()
            {
                Cruise =  cruise,
                ParticipantReservations = reservations
            };
            return View(administrationReservationViewModel);
            
        }


        // GET: Reservations
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reservations = await _context.Reservations
                .Include(r => r.Cruise)
                .Where(r => r.UserId == userId)
                .OrderBy(r => r.Cruise.CruiseId)
                .ToListAsync();

            return View(reservations);

        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var participants =  await _context.Participant.ToListAsync();
            var reservation = await _context.Reservations
                .Include(r=>r.Cruise).ThenInclude(c=>c.TypeCruise)
                .Include(r=>r.Participants)
                .Where(r=>r.UserId == userId)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public async Task<IActionResult> Create(int?id)
        {
            try
            {
                var cruise =  _context.Cruises
                    .Include(c=>c.Boat)
                    .Include(c=>c.PortDepart)
                    .Include(c=>c.ArrivalPort)
                    .Include(c=>c.TypeCruise)
                    .First(c => c.CruiseId == id);

                var allReservations =await _context.ParticipantReservations.Include(p => p.Reservation).ThenInclude(p => p.Cruise)
                    .Where(p => p.Reservation.Cruise.CruiseId == id).ToListAsync();

                var nbReservation = allReservations.Count;
                var nbTotalPlace = cruise.Boat.NbConvives;
                var placeDispo = nbTotalPlace - nbReservation;
                if (placeDispo == 0)
                {
                    return RedirectToAction("Index", "Home");
                }

                return View(new ReservationViewModel() { Cruise = cruise, PlaceRestante = placeDispo});
            }
            catch(Exception)
            {
                return RedirectToAction("Index", "Home");
            }

        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservationViewModel reservationViewModel)
        {

            var cruise = await _context.Cruises.Include(c=>c.Boat).Include(c=>c.TypeCruise).FirstAsync(c => c.CruiseId == reservationViewModel.CruiseId);
            if (ModelState.IsValid)
            {
                var participants = reservationViewModel.Participants;
                var reservation = new Reservation(){Cruise = cruise};
                var usersReservations = new List<ParticipantReservation>();
                foreach (var participant in participants)
                {
                    if(!participant.Name.Equals("-1") && !participant.FirstName.Equals("-1"))
                        usersReservations.Add(new ParticipantReservation(){Reservation = reservation, Participant = participant});
                }

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                reservation.Participants = usersReservations;
                reservation.UserId = userId;
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            if (cruise != null)
            {
                var allReservations = await _context.ParticipantReservations.Include(p => p.Reservation).ThenInclude(p => p.Cruise)
                    .Where(p => p.Reservation.Cruise.CruiseId == cruise.CruiseId).ToListAsync();

                var nbReservation = allReservations.Count;
                int nbTotalPlace = cruise.Boat.NbConvives;
                int placeDispo = nbTotalPlace - nbReservation;
                reservationViewModel.Cruise = cruise;
                reservationViewModel.PlaceRestante = placeDispo-reservationViewModel.Participants.Count;
                return View(reservationViewModel);
            }
            return RedirectToAction("Index", "Home");
            
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var participants = await _context.Participant.ToListAsync();
            var reservation = await _context.Reservations
                .Include(r => r.Cruise).ThenInclude(c => c.TypeCruise)
                .Include(r => r.Participants)
                .Where(r=>r.UserId==userId)
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        [Produces("application/json")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editer()
        {
            var reservationId = int.Parse(HttpContext.Request.Query["reservationId"].ToString());
            var removed = HttpContext.Request.Query["removed"].ToArray();
            try
            {
                var userRes = await _context.ParticipantReservations.Where(p => p.ReservationId == reservationId)
                    .ToListAsync();
                foreach (var userReservation in userRes)
                {
                    if (removed.Contains(userReservation.ParticipantId.ToString()))
                    {
                        _context.ParticipantReservations.Remove(userReservation);
                        var participant = await _context.Participant
                            .Where(p => p.ParticipantId == userReservation.ParticipantId).FirstAsync();
                        _context.Participant.Remove(participant);
                    }
                }

                if (removed.Length == userRes.Count)
                {
                    var reservation = _context.Reservations.First(r => r.ReservationId == reservationId);
                    _context.Reservations.Remove(reservation);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(reservationId))
                {
                    return NotFound();
                }
            }

            return Json(new {redirectToUrl = Url.Action("Index")});
        }


        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationId == id);
        }
    }
}
