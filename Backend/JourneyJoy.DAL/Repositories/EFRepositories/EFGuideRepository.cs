using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;

namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFGuideRepository(AppDbContext context) : GenericRepository<Guide>(context), IGuideDAL
    {
        public async Task ChangeStatus(Guide guide)
        {
            guide.Status = !guide.Status;
            context.Update(guide);
            await context.SaveChangesAsync();
        }
    }
}
