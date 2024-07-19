using JourneyJoy.UI.Core.Dtos.AuthDtos;
using JourneyJoy.UI.Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Controllers
{
    [Route("{controller}")]
    public class AuthController(IAuthService authService) : BaseController
    {
        [HttpGet("SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(LoginDto loginDto)
        {
            var response = await authService.LoginAsync(loginDto);
            if (response.Success)
            {
                int id = (response.Data.UserInfo.Id);
                if (response.Data.UserInfo.Roles.Contains("Member"))
                    return RedirectToAction("MyDashboard", "Dashboard", new { area = "Member", id });
                return RedirectToAction("MemberList", "Member", new { area = "Admin" });
            }
            return HandleErrorResponse(response, "SignIn", loginDto);
        }

        [HttpGet("SignUp")]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(RegisterDto registerDto)
        {
            var response = await authService.RegisterAsync(registerDto);
            if (response.Success)
                return RedirectToAction("SignIn");
            return HandleErrorResponse(response, "SignUp", registerDto);
        }
    }
}
