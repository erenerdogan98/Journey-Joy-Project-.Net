using AutoMapper;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.AnnouncementDtos;
using JourneyJoy.Entities;

namespace JourneyJoy.BLL.Concrete
{
    public class AnnouncementManager(IAnnouncementDAL AnnouncementDAL, IMapper mapper) : GenericManager<Announcement, CreateAnnouncementDto, UpdateAnnouncementDto, ResultAnnouncementDto>(AnnouncementDAL, mapper), IAnnouncementService
    {
    }
}
