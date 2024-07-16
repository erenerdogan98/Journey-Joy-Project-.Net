using AutoMapper;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.GetContactDtos;
using JourneyJoy.Entities;

namespace JourneyJoy.BLL.Concrete
{
    public class GetContactManager(IGetContactDAL GetContactDAL, IMapper mapper) : GenericManager<GetContact, CreateGetContactDto, UpdateGetContactDto, ResultGetContactDto>(GetContactDAL, mapper), IGetContactService
    {
    }
}
