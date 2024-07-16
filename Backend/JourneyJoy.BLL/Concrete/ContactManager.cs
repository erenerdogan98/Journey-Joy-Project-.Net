using AutoMapper;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.ContactDtos;
using JourneyJoy.Entities;

namespace JourneyJoy.BLL.Concrete
{
    public class ContactManager(IContactDAL ContactDAL, IMapper mapper) : GenericManager<Contact, CreateContactDto, UpdateContactDto, ResultContactDto>(ContactDAL, mapper), IContactService
    {
    }
}
