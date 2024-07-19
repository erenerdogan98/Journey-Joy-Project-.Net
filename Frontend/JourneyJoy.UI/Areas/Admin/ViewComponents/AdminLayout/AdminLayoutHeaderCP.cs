using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Admin.ViewComponents.AdminLayout
{
    public class AdminLayoutHeaderCP : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
