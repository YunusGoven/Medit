using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Medit1.Models;
using Microsoft.AspNetCore.Authorization;

namespace Medit1.Controllers
{
    [Authorize]
    public class TypeCruisesController : Controller
    {
        private readonly Medit1DbContext _context;

        public TypeCruisesController(Medit1DbContext context)
        {
            _context = context;
        }

        // GET: TypeCruises
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeCruises.ToListAsync());
        }

        // GET: TypeCruises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeCruise = await _context.TypeCruises
                .FirstOrDefaultAsync(m => m.TypeCruiseId == id);
            if (typeCruise == null)
            {
                return NotFound();
            }

            return View(typeCruise);
        }

        // GET: TypeCruises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeCruises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeCruiseId,Name,Description,AdultOnly")] TypeCruise typeCruise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeCruise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeCruise);
        }

        // GET: TypeCruises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeCruise = await _context.TypeCruises.FindAsync(id);
            if (typeCruise == null)
            {
                return NotFound();
            }
            return View(typeCruise);
        }

        // POST: TypeCruises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeCruiseId,Name,Description,AdultOnly")] TypeCruise typeCruise)
        {
            if (id != typeCruise.TypeCruiseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeCruise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeCruiseExists(typeCruise.TypeCruiseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(typeCruise);
        }

        // GET: TypeCruises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeCruise = await _context.TypeCruises
                .FirstOrDefaultAsync(m => m.TypeCruiseId == id);
            if (typeCruise == null)
            {
                return NotFound();
            }

            return View(typeCruise);
        }

        // POST: TypeCruises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeCruise = await _context.TypeCruises.FindAsync(id);
            _context.TypeCruises.Remove(typeCruise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeCruiseExists(int id)
        {
            return _context.TypeCruises.Any(e => e.TypeCruiseId == id);
        }
    }
}
