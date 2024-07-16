using JourneyJoy.BLL.Abstract;
using JourneyJoy.DTO.AnnouncementDtos;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController(IAnnouncementService announcementService) : BaseController
    { // Get All By List 
        [HttpGet]
        public async Task<IActionResult> GetAnnouncements()
        {
            var response = await announcementService.TGetAllAsync();
            return CreateApiResponse(response);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncementById(int id)
        {
            var response = await announcementService.TGetByIdAsync(id);
            return CreateApiResponse(response);
        }

        // Create 
        // For FromBody attribute , it will check model (also My rules with Fluent Validation)
        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement([FromBody] CreateAnnouncementDto createAnnouncementDto)
        {
            var response = await announcementService.TAddAsync(createAnnouncementDto);
            return CreateApiResponse(response);
        }

        // Delete for by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            var response = await announcementService.TDeleteAsync(id);
            return CreateApiResponse(response);
        }

        // Update
        [HttpPut]
        public IActionResult UpdateAnnouncement([FromBody] UpdateAnnouncementDto updateAnnouncementDto)
        {
            var response = announcementService.TUpdate(updateAnnouncementDto);
            return CreateApiResponse(response);
        }
    }
}
