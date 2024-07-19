using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Member.ViewComponents.MemberLayout
{
    public class MemberLayoutSidebarCP : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
