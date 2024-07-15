using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;

namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFCommentRepository(AppDbContext context) : GenericRepository<Comment>(context), ICommentDAL
    {
    }
}
