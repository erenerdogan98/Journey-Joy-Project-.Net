using JourneyJoy.BLL.Abstract;
using JourneyJoy.DTO.FeatureDtos;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController(IFeatureService featureService) : BaseController
    {    
        // Get All By List 
        [HttpGet]
        public async Task<IActionResult> GetFeatures()
        {
            var response = await featureService.TGetAllAsync();
            return CreateApiResponse(response);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            var response = await featureService.TGetByIdAsync(id);
            return CreateApiResponse(response);
        }

        // Create 
        // For FromBody attribute , it will check model (also My rules with Fluent Validation)
        [HttpPost]
        public async Task<IActionResult> CreateFeature([FromBody] CreateFeatureDto createFeatureDto)
        {
            var response = await featureService.TAddAsync(createFeatureDto);
            return CreateApiResponse(response);
        }

        // Delete for by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var response = await featureService.TDeleteAsync(id);
            return CreateApiResponse(response);
        }

        // Update
        [HttpPut]
        public IActionResult UpdateFeature([FromBody] UpdateFeatureDto updateFeatureDto)
        {
            var response = featureService.TUpdate(updateFeatureDto);
            return CreateApiResponse(response);
        }
    }
}
