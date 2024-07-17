using JourneyJoy.UI.Core.Dtos.AnnouncementDtos;
using JourneyJoy.UI.Core.Helper;
using JourneyJoy.UI.Core.Services.Abstract;

namespace JourneyJoy.UI.Core.Services.Concrete
{
    public class AnnouncementService(HttpClientHelper httpClient) : GenericService<CreateAnnouncementDto, UpdateAnnouncementDto, ResultAnnouncementDto, int>(httpClient), IAnnouncementService
    {
    }
}
