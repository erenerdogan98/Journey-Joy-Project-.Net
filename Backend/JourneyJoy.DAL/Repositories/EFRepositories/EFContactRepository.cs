using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;

namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFContactRepository(AppDbContext context) : GenericRepository<Contact>(context), IContactDAL
    {
    }
}
