using JourneyJoy.UI.Core.Dtos.AnnouncementDtos;

namespace JourneyJoy.UI.Core.Services.Abstract
{
    public interface IAnnouncementService : IGenericService<CreateAnnouncementDto, UpdateAnnouncementDto, ResultAnnouncementDto, int>
    {
    }
}
