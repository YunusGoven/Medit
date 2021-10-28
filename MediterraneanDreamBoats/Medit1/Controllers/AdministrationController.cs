using System.Threading.Tasks;
using Medit1.Models;
using Medit1.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Medit1.Controllers
{
    [Authorize(Roles = "Director")]
    public class AdministrationController : Controller
    {
        private readonly Medit1DbContext _context;

        public AdministrationController(Medit1DbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var administrationViewModel = new AdministrationViewModel
            {
                Boats = await _context.Boats.ToListAsync(),
                Cruises = await _context.Cruises.ToListAsync(),
                Ports = await _context.Ports.ToListAsync()
            };
            return View(administrationViewModel);
        }
    }
}
