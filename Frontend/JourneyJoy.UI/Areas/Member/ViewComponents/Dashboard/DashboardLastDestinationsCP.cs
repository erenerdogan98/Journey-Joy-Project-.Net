using JourneyJoy.UI.Core.Services.Abstract;
using JourneyJoy.UI.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Member.ViewComponents.Dashboard
{
    public class DashboardLastDestinationsCP(IDestinationService destinationService) : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await destinationService.GetLastFourDestinationsAsync();
            if (response.Success)
                return View(response.Data);
            return HandleError(response.statusCode);
        }
    }
}
