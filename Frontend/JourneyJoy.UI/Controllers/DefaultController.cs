using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
