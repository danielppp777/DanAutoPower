using Microsoft.AspNetCore.Mvc;
using DanAutoPower.Models;
using Microsoft.EntityFrameworkCore;
using DanAutoPower.Data;

namespace DanAutoPower.Controllers
{
    public class TestDriveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestDriveController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Show all scheduled test drives
        public IActionResult Index()
        {
            var testDrives = _context.TestDrives
                                     .Include(td => td.Car)
                                     .ToList();

            // Pass the cars list to the view for the form
            var cars = _context.Cars.ToList();
            ViewBag.Cars = cars;

            return View(testDrives);
        }

        // Handle test drive requests (via AJAX)
        [HttpPost]
        public IActionResult Create(TestDrive testDrive)
        {
            if (ModelState.IsValid)
            {
                _context.TestDrives.Add(testDrive);
                _context.SaveChanges();

                // Return success message for AJAX
                return Ok();
            }

            // Return error if the data isn't valid
            return BadRequest("Възникна грешка при заявката.");
        }
    }
}
