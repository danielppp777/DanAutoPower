using Microsoft.AspNetCore.Mvc;

namespace DanAutoPower.Controllers
{
    public class TestDrive : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
