using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;

namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFGetContactRepository(AppDbContext context) : GenericRepository<GetContact>(context), IGetContactDAL
    {
    }
}
