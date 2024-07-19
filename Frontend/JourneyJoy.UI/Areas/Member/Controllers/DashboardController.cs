using JourneyJoy.UI.Controllers;
using JourneyJoy.UI.Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/{controller}")]
    public class DashboardController(IAuthService authService) : BaseController
    {
        [HttpGet("MyDashboard")]
        public async Task<IActionResult> MyDashboard(int id)
        {
            var response = await authService.GetUserById(id);
            var userInfo = response.Data;
            if (response.Success)
                return View(userInfo);
            return HandleErrorResponse(response, "MyDashboard", userInfo);
        }
    }
}
