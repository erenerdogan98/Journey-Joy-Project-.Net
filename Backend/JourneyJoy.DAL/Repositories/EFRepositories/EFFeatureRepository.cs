using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;

namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFFeatureRepository(AppDbContext context) : GenericRepository<Feature>(context), IFeatureDAL
    {
    }
}
