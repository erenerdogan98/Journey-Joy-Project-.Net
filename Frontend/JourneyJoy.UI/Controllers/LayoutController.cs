using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult UILayout()
        {
            return View();
        }
    }
}
