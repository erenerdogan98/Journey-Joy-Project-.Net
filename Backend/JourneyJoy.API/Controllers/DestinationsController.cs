using JourneyJoy.BLL.Abstract;
using JourneyJoy.DTO.DestinationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController(IDestinationService destinationService) : BaseController
    {
        // Get All By List 
        [HttpGet]
        public async Task<IActionResult> GetDestinations()
        {
            var response = await destinationService.TGetAllAsync();
            return CreateApiResponse(response);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDestinationById(int id)
        {
            var response = await destinationService.TGetByIdAsync(id);
            return CreateApiResponse(response);
        }

        [HttpGet("LastFour")]
        public async Task<IActionResult> GetLastFourDestinations()
        {
            var response = await destinationService.TGetLastFourDestinationsAsync();
            return CreateApiResponse(response);
        }

        // Create 
        // For FromBody attribute , it will check model (also My rules with Fluent Validation)
        [HttpPost]
        public async Task<IActionResult> CreateDestination([FromBody] CreateDestinationDto createDestinationDto)
        {
            var response = await destinationService.TAddAsync(createDestinationDto);
            return CreateApiResponse(response);
        }

        // Delete for by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            var response = await destinationService.TDeleteAsync(id);
            return CreateApiResponse(response);
        }

        // Update
        [HttpPut]
        public IActionResult UpdateDestination([FromBody] UpdateDestinationDto updateDestinationDto)
        {
            var response = destinationService.TUpdate(updateDestinationDto);
            return CreateApiResponse(response);
        }
    }
}
