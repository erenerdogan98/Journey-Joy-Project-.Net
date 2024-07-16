using JourneyJoy.DTO.ContactDtos;

namespace JourneyJoy.BLL.Abstract
{
    public interface IContactService : IGenericService<CreateContactDto, UpdateContactDto, ResultContactDto>
    {
    }
}
