using AutoMapper;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.FeatureDtos;
using JourneyJoy.Entities;

namespace JourneyJoy.BLL.Concrete
{
    public class FeatureManager(IFeatureDAL FeatureDAL, IMapper mapper) : GenericManager<Feature, CreateFeatureDto, UpdateFeatureDto, ResultFeatureDto>(FeatureDAL, mapper), IFeatureService
    {
    }
}
