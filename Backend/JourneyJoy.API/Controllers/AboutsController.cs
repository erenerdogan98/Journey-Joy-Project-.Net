using JourneyJoy.BLL.Abstract;
using JourneyJoy.DTO.AboutDtos;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(IAboutSerivce aboutService) : BaseController
    {
        // Get All By List 
        [HttpGet]
        public async Task<IActionResult> GetAbouts()
        {
            var response = await aboutService.TGetAllAsync();
            return CreateApiResponse(response);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var response = await aboutService.TGetByIdAsync(id);
            return CreateApiResponse(response);
        }

        // Create 
        // For FromBody attribute , it will check model (also My rules with Fluent Validation)
        [HttpPost]
        public async Task<IActionResult> CreateAbout([FromBody] CreateAboutDto createAboutDto)
        {
            var response = await aboutService.TAddAsync(createAboutDto);
            return CreateApiResponse(response);
        }

        // Delete for by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var response = await aboutService.TDeleteAsync(id);
            return CreateApiResponse(response);
        }

        // Update
        [HttpPut]
        public IActionResult UpdateAbout([FromBody] UpdateAboutDto updateAboutDto)
        {
            var response = aboutService.TUpdate(updateAboutDto);
            return CreateApiResponse(response);
        }
    }
}
