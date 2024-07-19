using JourneyJoy.UI.Controllers;
using JourneyJoy.UI.Core.Dtos.AuthDtos;
using JourneyJoy.UI.Core.Services.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/{controller}")]
    public class ProfileController(IAuthService authService, IWebHostEnvironment webHostEnvironment) : BaseController
    {
        // will write later ..
        [HttpGet]
        public IActionResult MyProfile()
        {
            return View();
        }

        [HttpGet("EditProfile/{id}")]
        public async Task<IActionResult> EditProfile(int id)
        {
            var response = await authService.GetUserById(id);
            var userInfo = response.Data;
            if (response.Success)
                return View(userInfo);
            return HandleErrorResponse(response,"EditProfile",userInfo);
        }

        [HttpPost("EditProfile")]
        public async Task<IActionResult> EditProfile(UserInfoResult updateProfileDto)
        {
            var response = await authService.UpdateProfile(updateProfileDto);
            if (response.Success)
                return RedirectToAction("EditProfile");
            return HandleErrorResponse(response, "EditProfile", updateProfileDto);
        }

        private void SaveImage(IFormFile image, UpdateProfileDto user)
        {
            var wwwrootPath = webHostEnvironment.WebRootPath;
            var extension = Path.GetExtension(image.FileName);
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = Path.Combine(wwwrootPath, "userimages", imageName);

            using (var stream = new FileStream(saveLocation, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            user.ImageUrl = imageName;
        }
    }
}
