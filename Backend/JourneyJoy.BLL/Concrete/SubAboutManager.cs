using AutoMapper;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.SubAboutDtos;
using JourneyJoy.Entities;

namespace JourneyJoy.BLL.Concrete
{
    public class SubAboutManager(ISubAboutDAL SubAboutDAL, IMapper mapper) : GenericManager<SubAbout, CreateSubAboutDto, UpdateSubAboutDto, ResultSubAboutDto>(SubAboutDAL, mapper), ISubAboutService
    {
    }
}
