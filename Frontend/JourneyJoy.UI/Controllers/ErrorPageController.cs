using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Error500()
        {
            return View();
        }
    }
}
