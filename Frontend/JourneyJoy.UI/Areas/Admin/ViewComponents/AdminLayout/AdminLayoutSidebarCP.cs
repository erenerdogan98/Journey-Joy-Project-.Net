using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Admin.ViewComponents.AdminLayout
{
    public class AdminLayoutSidebarCP : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
