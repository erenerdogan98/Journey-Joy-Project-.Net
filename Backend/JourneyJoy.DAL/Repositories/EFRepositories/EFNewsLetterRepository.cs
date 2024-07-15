using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;

namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFNewsLetterRepository(AppDbContext context) : GenericRepository<NewsLetter>(context), INewsLetterDAL
    {
    }
}
