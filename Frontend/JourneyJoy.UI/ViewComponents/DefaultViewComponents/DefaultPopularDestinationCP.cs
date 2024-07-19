using JourneyJoy.UI.Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.ViewComponents.DefaultViewComponents
{
    // CP Means Component Partial
    public class DefaultPopularDestinationCP(IDestinationService destinationService) : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() // if method will async then name will InvokeAsync then
        {
            var response = await destinationService.GetAllAsync("destinations");
            if (response.Success)
                return View(response.Data);
            return HandleError(response.statusCode);
        }
    }
}
