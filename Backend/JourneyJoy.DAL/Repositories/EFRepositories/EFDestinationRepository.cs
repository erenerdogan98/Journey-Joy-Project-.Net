using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;
using Microsoft.EntityFrameworkCore;

namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFDestinationRepository(AppDbContext context) : GenericRepository<Destination>(context), IDestinationDAL
    {
        public async Task<IEnumerable<Destination>> GetLastFourDestinationAsync() =>

            //await context.Destinations.TakeLast(4).OrderByDescending(x => x.Id).ToListAsync();
             await QueryWithIncludes()
                  .OrderByDescending(d => d.Id)  
                  .Take(4)
                  .ToListAsync();

    }
}
