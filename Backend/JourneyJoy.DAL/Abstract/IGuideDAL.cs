using JourneyJoy.Entities;

namespace JourneyJoy.DAL.Abstract
{
    public interface IGuideDAL : IGenericDAL<Guide>
    {
        Task ChangeStatus(Guide guide);
    }
}
