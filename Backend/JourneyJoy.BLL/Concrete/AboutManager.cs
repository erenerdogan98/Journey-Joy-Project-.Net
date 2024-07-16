using AutoMapper;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.AboutDtos;
using JourneyJoy.Entities;

namespace JourneyJoy.BLL.Concrete
{
    public class AboutManager(IAboutDAL aboutDAL, IMapper mapper) : GenericManager<About, CreateAboutDto, UpdateAboutDto, ResultAboutDto>(aboutDAL, mapper), IAboutSerivce
    {
    }
}
