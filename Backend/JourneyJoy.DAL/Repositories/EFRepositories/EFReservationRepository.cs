using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;


namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFReservationRepository(AppDbContext context) : GenericRepository<Reservation>(context), IReservationDAL
    {
       
    }
}
