using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;

namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFTestimonialRepository(AppDbContext context) : GenericRepository<Testimonial>(context), ITestimonialDAL
    {
    }
}
