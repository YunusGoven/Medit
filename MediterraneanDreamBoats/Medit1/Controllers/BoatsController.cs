using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medit1.Models;
using Microsoft.AspNetCore.Authorization;


namespace Medit1.Controllers
{
    [Authorize]
    public class BoatsController : Controller
    {
        private readonly Medit1DbContext _context;

        public BoatsController(Medit1DbContext context)
        {
            _context = context;
        }



        // GET: Boats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Type,NbConvives")] Boat boat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boat);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Administration");
            }
            return View(boat);
        }

        // GET: Boats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = await _context.Boats.FindAsync(id);
            if (boat == null)
            {
                return NotFound();
            }
            return View(boat);
        }

        // POST: Boats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BoatId,Name,Description,Type,NbConvives")] Boat boat)
        {
            if (id != boat.BoatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoatExists(boat.BoatId))
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
            return View(boat);
        }

        // GET: Boats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = await _context.Boats
                .FirstOrDefaultAsync(m => m.BoatId == id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }

        // POST: Boats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boat = await _context.Boats.FindAsync(id);
            _context.Boats.Remove(boat);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Administration");
        }

        private bool BoatExists(int id)
        {
            return _context.Boats.Any(e => e.BoatId == id);
        }
        // GET: Boats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boat = await _context.Boats
                .FirstOrDefaultAsync(m => m.BoatId == id);
            if (boat == null)
            {
                return NotFound();
            }

            return View(boat);
        }


    }
}
