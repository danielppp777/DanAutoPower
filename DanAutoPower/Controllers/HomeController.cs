using Microsoft.AspNetCore.Mvc;
using DanAutoPower.Models; // добави това, за да можеш да използваш моделите
using System.Collections.Generic;

namespace DanAutoPower.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public IActionResult Index()

        {
            // Създаваме примерни данни за автомобили, за да ги покажем в изгледа
            var cars = new List<Car>
            { 
                new Car { Brand = "BMW", Model = "X5", Year = 2022, Price = 55000, ImageUrl = "/images/resizer.jpg " },
                new Car { Brand = "Mercedes", Model = "GLE", Year = 2021, Price = 65000, ImageUrl = "/images/mercedes_gle.jpg" },
                new Car { Brand = "Audi", Model = "Q7", Year = 2020, Price = 58000, ImageUrl = "/images/audi_q7.jpg" }
            };

            return View(cars); // Изпращаме данните към изгледа
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Brand,Model,Year,Price,ImageUrl")] Car car)
        {
            if (ModelState.IsValid)
            {
                // Тук ще добавиш логиката за добавяне на колата към базата данни
                // В момента просто показваме, че данните се приемат
                return RedirectToAction(nameof(Index)); // Пренасочваме към списъка с автомобили
            }

            return View(car); // Ако има грешка, връщаме обратно към формата за създаване




        }
    }
}
