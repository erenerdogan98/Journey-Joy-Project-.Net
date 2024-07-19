using JourneyJoy.UI.Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.ViewComponents.DefaultViewComponents
{
    public class DefaultSubAboutCP(ISubAboutService subAboutService) : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await subAboutService.GetAllAsync("subabouts");
            if (response.Success)
                return View(response.Data);
            return HandleError(response.statusCode);
        }
    }
}
