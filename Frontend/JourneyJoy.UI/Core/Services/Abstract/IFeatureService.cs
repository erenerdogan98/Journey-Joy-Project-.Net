using JourneyJoy.UI.Core.Dtos.FeatureDtos;

namespace JourneyJoy.UI.Core.Services.Abstract
{
    public interface IFeatureService : IGenericService<CreateFeatureDto, UpdateFeatureDto, ResultFeatureDto,int>
    {
    }
}
