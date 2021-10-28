using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Medit1.Models;
using Microsoft.EntityFrameworkCore;

namespace Medit1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Medit1DbContext _context;

        public HomeController(ILogger<HomeController> logger,Medit1DbContext context)
        {
            _context = context;
            _logger = logger;
        }
        [ResponseCache(Duration = 60*60*24, Location = ResponseCacheLocation.Any, NoStore = false)]
        public async Task<IActionResult> Index()
        {
            var port = await _context.Ports.ToListAsync();
            return View(port);
        }


        [ResponseCache(Duration = 60*60*24, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
