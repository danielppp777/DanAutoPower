using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DanAutoPower.Data;
using DanAutoPower.Models;

public class CarsController : Controller
{
    private readonly ApplicationDbContext _context;

    public CarsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 🟢 GET: Cars/Index (Списък с всички автомобили)
    public async Task<IActionResult> Index()
    {
        var cars = await _context.Cars.ToListAsync();
        return View(cars);
    }

    // 🟢 GET: Cars/Details/5 (Детайли за автомобил)
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
        if (car == null) return NotFound();

        return View(car);
    }

    // 🟢 GET: Cars/Create (Форма за създаване на нов автомобил)
    public IActionResult Create()
    {
        return View();
    }

    // 🔵 POST: Cars/Create (Записване в базата)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Year,Kilometers,Fuel,Price")] Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }

    // 🟠 GET: Cars/Edit/5 (Форма за редактиране)
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var car = await _context.Cars.FindAsync(id);
        if (car == null) return NotFound();

        return View(car);
    }

    // 🔵 POST: Cars/Edit/5 (Записване на редактираните данни)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Year,Kilometers,Fuel,Price")] Car car)
    {
        if (id != car.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(car);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cars.Any(e => e.Id == car.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(car);
    }

    // 🔴 GET: Cars/Delete/5 (Форма за потвърждение на изтриването)
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var car = await _context.Cars.FirstOrDefaultAsync(m => m.Id == id);
        if (car == null) return NotFound();

        return View(car);
    }

    // 🔴 POST: Cars/Delete/5 (Изтриване на автомобил)
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car != null)
        {
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}