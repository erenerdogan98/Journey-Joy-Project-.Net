using JourneyJoy.UI.Core.Services.Abstract;
using JourneyJoy.UI.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Admin.ViewComponents.AdminLayout
{
    public class AdminLayoutNavbarCP(IAuthService authService) : BaseViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int id = int.Parse(authService.GetUserId());
            var response = await authService.GetUserById(id);
            if (response.Success && response.Data.Roles.Contains("Admin"))
                return View(response.Data);
            return HandleError(response.statusCode);
        }
    }
}
