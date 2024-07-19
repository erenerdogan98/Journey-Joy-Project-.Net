using JourneyJoy.UI.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Admin.ViewComponents.AdminDashboard
{
    public class AdminDashboardHeaderCP : BaseViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
