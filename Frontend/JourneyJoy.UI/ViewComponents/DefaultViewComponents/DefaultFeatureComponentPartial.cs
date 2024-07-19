using JourneyJoy.UI.Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.ViewComponents.DefaultViewComponents
{
    public class DefaultFeatureComponentPartial(IFeatureService featureService) : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await featureService.GetAllAsync("features");
            if (response.Success)
                return View(response.Data);
            return HandleError(response.statusCode);
        }
    }
}
