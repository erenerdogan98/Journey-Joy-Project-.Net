using JourneyJoy.UI.Controllers;
using JourneyJoy.UI.Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Admin.Controllers
{
    public class MemberController(IAuthService authService) : BaseController
    {
        [HttpGet("MemberList")]
        public async Task<IActionResult> MemberList()
        {
            var response = await authService.GetAllMembers();
            var values = response.Data;
            if (response.Success)
                View(values);
            return HandleErrorResponse(response, "MemberList", values);
        }
    }
}
