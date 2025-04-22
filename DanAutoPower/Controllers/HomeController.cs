using Microsoft.AspNetCore.Mvc;
using DanAutoPower.Models;
using DanAutoPower.Data;
using System.Linq;

namespace DanAutoPower.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var recentCars = _context.Cars
                .OrderByDescending(c => c.Id)
                .Take(9)
                .ToList();

            return View(recentCars);
        }
    }
}