using Microsoft.AspNetCore.Mvc;

namespace EmreAydogduoglu.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NotFound(int code)
        {
            ViewBag.Code = code;
            return View();
        }
    }
}
