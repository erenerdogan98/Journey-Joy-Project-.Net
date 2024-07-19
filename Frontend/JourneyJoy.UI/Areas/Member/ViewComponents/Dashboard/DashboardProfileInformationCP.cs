using JourneyJoy.UI.Core.Services.Abstract;
using JourneyJoy.UI.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Member.ViewComponents.Dashboard
{
    public class DashboardProfileInformationCP(IAuthService authService) : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var response = await authService.GetUserById(id);
            if (response.Success)
                return View(response.Data);
           return HandleError(response.statusCode);
        }
    }
}
