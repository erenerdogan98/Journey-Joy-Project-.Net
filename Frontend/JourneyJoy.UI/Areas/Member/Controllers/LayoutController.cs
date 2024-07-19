using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Member.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult MemberLayout()
        {
            return View();
        }
    }
}
