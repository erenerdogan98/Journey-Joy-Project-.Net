using JourneyJoy.UI.Core.Helper;
using JourneyJoy.UI.Core.Services.Abstract;
using JourneyJoy.UI.Core.Dtos.SubAboutDtos;

namespace JourneyJoy.UI.Core.Services.Concrete
{
    public class SubAboutService(HttpClientHelper httpClientHelper) : GenericService<CreateSubAboutDto, UpdateSubAboutDto, ResultSubAboutDto, int>(httpClientHelper), ISubAboutService
    {
    }
}
