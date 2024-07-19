using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Admin.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult AdminLayout()
        {
            return View();
        }
    }
}
