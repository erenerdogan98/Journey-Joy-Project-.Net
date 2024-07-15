using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;

namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFAnnouncementRepository(AppDbContext context) : GenericRepository<Announcement>(context), IAnnouncementDAL
    {
    }
}
