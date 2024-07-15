using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;

namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFAboutRepository(AppDbContext context) : GenericRepository<About>(context), IAboutDAL
    {
    }
}
