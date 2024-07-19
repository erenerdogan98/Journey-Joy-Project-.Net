using JourneyJoy.UI.Core.Services.Abstract;
using JourneyJoy.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.ViewComponents.DefaultViewComponents
{
    public class DefaultStatisticsCP(IDestinationService destinationService, IGuideService guideService) : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseDestination = await destinationService.GetAllAsync("destinations");
            if (!responseDestination.Success)
                return HandleError(responseDestination.statusCode);
            int destinationCount = responseDestination.Data.Count();

            var responseGuide = await guideService.GetAllAsync("guides");
            if (!responseGuide.Success)
                return HandleError(responseGuide.statusCode);

            int guidesCount = responseGuide.Data.Count();
            var model = new StatisticsViewModel
            {
                GuideCount = guidesCount,
                DestinationCount = destinationCount,
                CustomerCount = 200
            };
            return View(model);
        }
    }
}
