using JourneyJoy.BLL.Abstract;
using JourneyJoy.DTO.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(ITestimonialService testimonialService) : BaseController
    {

        // Get All By List 
        [HttpGet]
        public async Task<IActionResult> GetTestimonials()
        {
            var response = await testimonialService.TGetAllAsync();
            return CreateApiResponse(response);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            var response = await testimonialService.TGetByIdAsync(id);
            return CreateApiResponse(response);
        }

        // Create 
        // For FromBody attribute , it will check model (also My rules with Fluent Validation)
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial([FromBody] CreateTestimonialDto createTestimonialDto)
        {
            var response = await testimonialService.TAddAsync(createTestimonialDto);
            return CreateApiResponse(response);
        }

        // Delete for by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var response = await testimonialService.TDeleteAsync(id);
            return CreateApiResponse(response);
        }

        // Update
        [HttpPut]
        public IActionResult UpdateTestimonial([FromBody] UpdateTestimonialDto updateTestimonialDto)
        {
            var response = testimonialService.TUpdate(updateTestimonialDto);
            return CreateApiResponse(response);
        }
    }
}
