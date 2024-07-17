using JourneyJoy.UI.Core.Dtos.FeatureDtos;
using JourneyJoy.UI.Core.Helper;
using JourneyJoy.UI.Core.Services.Abstract;

namespace JourneyJoy.UI.Core.Services.Concrete
{
    public class FeatureService(HttpClientHelper httpClientHelper) : GenericService<CreateFeatureDto, UpdateFeatureDto, ResultFeatureDto, int>(httpClientHelper), IFeatureService
    {
    }
}
