using JourneyJoy.BLL.Abstract;
using JourneyJoy.DTO.GetContactDtos;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetContactsController(IGetContactService contactService) : BaseController
    {
        // For the people can contact with us.

        // Get All By List 
        [HttpGet]
        public async Task<IActionResult> ListGetContacts()
        {
            var response = await contactService.TGetAllAsync();
            return CreateApiResponse(response);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactUsById(int id)
        {
            var response = await contactService.TGetByIdAsync(id);
            return CreateApiResponse(response);
        }

        // Create 
        // For FromBody attribute , it will check model (also My rules with Fluent Validation)
        [HttpPost]
        public async Task<IActionResult> CreateGetContact([FromBody] CreateGetContactDto createGetContactDto)
        {
            var response = await contactService.TAddAsync(createGetContactDto);
            return CreateApiResponse(response);
        }

        // Delete for by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGetContact(int id)
        {
            var response = await contactService.TDeleteAsync(id);
            return CreateApiResponse(response);
        }

        // Update
        [HttpPut]
        public IActionResult UpdateContact([FromBody] UpdateGetContactDto updateContactDto)
        {
            var response = contactService.TUpdate(updateContactDto);
            return CreateApiResponse(response);
        }

        [HttpGet("Statustrue")]
        public async Task<IActionResult> ListGetContactsByTrue()
        {
            var response = await contactService.TGetAllAsync(x => x.MessageStatus == true);
            return CreateApiResponse(response);
        }
    }
}
