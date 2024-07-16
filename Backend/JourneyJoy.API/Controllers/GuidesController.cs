using JourneyJoy.BLL.Abstract;
using JourneyJoy.DTO.GuideDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GuidesController(IGuideService guideService) : BaseController
    {
        // That create-update-delete operations for only admin .. 

        // Get All By List 
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetGuides()
        {
            var response = await guideService.TGetAllAsync();
            return CreateApiResponse(response);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGuideById(int id)
        {
            var response = await guideService.TGetByIdAsync(id);
            return CreateApiResponse(response);
        }

        [AllowAnonymous]
        [HttpGet("active")]
        public async Task<IActionResult> GetGuidesByStatusTrue()
        {
            var response = await guideService.TGetAllAsync(x => x.Status == true);
            return CreateApiResponse(response);
        }

        // Create 
        // For FromBody attribute , it will check model (also My rules with Fluent Validation)
        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateGuide([FromBody] CreateGuideDto createGuideDto)
        {
            var response = await guideService.TAddAsync(createGuideDto);
            return CreateApiResponse(response);
        }

        // Delete for by Id
        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuide(int id)
        {
            var response = await guideService.TDeleteAsync(id);
            return CreateApiResponse(response);
        }

        // Update
        [Authorize("Admin")]
        [HttpPut]
        public IActionResult UpdateGuide([FromBody] UpdateGuideDto updateGuideDto)
        {
            var response = guideService.TUpdate(updateGuideDto);
            return CreateApiResponse(response);
        }

        [Authorize("Admin")]
        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> ChangeStatusById(int id)
        {
            var response = await guideService.ChangeStatusByIdAsync(id);
            return CreateApiResponse(response);
        }
    }
}
