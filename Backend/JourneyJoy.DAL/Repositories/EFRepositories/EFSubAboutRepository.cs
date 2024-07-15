using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;

namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFSubAboutRepository(AppDbContext context) : GenericRepository<SubAbout>(context), ISubAboutDAL
    {
    }
}
