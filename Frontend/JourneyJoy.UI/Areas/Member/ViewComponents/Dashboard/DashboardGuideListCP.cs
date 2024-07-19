using JourneyJoy.UI.Core.Services.Abstract;
using JourneyJoy.UI.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Member.ViewComponents.Dashboard
{
    public class DashboardGuideListCP(IGuideService guideService) : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await guideService.GetAllAsync("guides");
            var values = response.Data;
            if (response.Success)
                return View(values);
            return HandleError(response.statusCode);
        }
    }
}
