using JourneyJoy.BLL.Abstract;
using JourneyJoy.DTO.SubAboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubAboutsController(ISubAboutService subAboutService) : BaseController
    {

        // Get All By List 
        [HttpGet]
        public async Task<IActionResult> GetSubAbouts()
        {
            var response = await subAboutService.TGetAllAsync();
            return CreateApiResponse(response);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubAboutById(int id)
        {
            var response = await subAboutService.TGetByIdAsync(id);
            return CreateApiResponse(response);
        }

        // Create 
        // For FromBody attribute , it will check model (also My rules with Fluent Validation)
        [HttpPost]
        public async Task<IActionResult> CreateSubAbout([FromBody] CreateSubAboutDto createSubAboutDto)
        {
            var response = await subAboutService.TAddAsync(createSubAboutDto);
            return CreateApiResponse(response);
        }

        // Delete for by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubAbout(int id)
        {
            var response = await subAboutService.TDeleteAsync(id);
            return CreateApiResponse(response);
        }

        // Update
        [HttpPut]
        public IActionResult UpdateSubAbout([FromBody] UpdateSubAboutDto updateSubAboutDto)
        {
            var response = subAboutService.TUpdate(updateSubAboutDto);
            return CreateApiResponse(response);
        }
    }
}
