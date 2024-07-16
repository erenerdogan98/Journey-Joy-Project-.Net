using JourneyJoy.BLL.Abstract;
using JourneyJoy.DTO.AuthDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController(IAuthService authService) : BaseController
    {
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto registerDto)
        {
            var response = await authService.CreateAccount(registerDto);
            return CreateApiResponse(response);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignInAsync([FromBody] LoginDto loginDto)
        {
            var response = await authService.LoginAsync(loginDto);
            return CreateApiResponse(response);
        }

        [HttpGet("GetUserInfo/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await authService.TGetUserById(id);
            return CreateApiResponse(response);
        }

        [HttpGet("UsersCount")]
        public async Task<IActionResult> GetUsersCount()
        {
            var response = await authService.TGetUserCountAsync();
            return CreateApiResponse(response);
        }

        //[Authorize("Admin")]
        [HttpGet("GetMembers")]
        public async Task<IActionResult> GetAllMembers()
        {
            var response = await authService.TGetAllMembersAsync();
            return CreateApiResponse(response);
        }

        //[Authorize("Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var response = await authService.TDeleteUserAsync(id);
            return CreateApiResponse(response);
        }

        [HttpPost("AddRole")]
    }
}
