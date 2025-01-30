using Microsoft.AspNetCore.Mvc;

namespace DanAutoPower.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using DanAutoPower.Data;
    using DanAutoPower.Models;

    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 🟢 GET: Services/Index (Списък с всички услуги)
        public async Task<IActionResult> Index()
        {
            var services = await _context.Services.ToListAsync();
            return View(services);
        }

        // 🟢 GET: Services/Details/5 (Детайли за услуга)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var service = await _context.Services.FirstOrDefaultAsync(m => m.Id == id);
            if (service == null) return NotFound();

            return View(service);
        }

        // 🟢 GET: Services/Create (Форма за създаване на услуга)
        public IActionResult Create()
        {
            return View();
        }

        // 🔵 POST: Services/Create (Записване в базата)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price")] Service service)
        {
            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // 🟠 GET: Services/Edit/5 (Форма за редактиране)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var service = await _context.Services.FindAsync(id);
            if (service == null) return NotFound();

            return View(service);
        }

        // 🔵 POST: Services/Edit/5 (Записване на редактираните данни)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price")] Service service)
        {
            if (id != service.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(service);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(service);
        }

        // 🔴 GET: Services/Delete/5 (Форма за потвърждение на изтриването)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var service = await _context.Services.FirstOrDefaultAsync(m => m.Id == id);
            if (service == null) return NotFound();

            return View(service);
        }

        // 🔴 POST: Services/Delete/5 (Изтриване на услуга)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }

}
