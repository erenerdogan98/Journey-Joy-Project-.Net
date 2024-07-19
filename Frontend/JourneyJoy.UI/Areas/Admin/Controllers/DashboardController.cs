using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
