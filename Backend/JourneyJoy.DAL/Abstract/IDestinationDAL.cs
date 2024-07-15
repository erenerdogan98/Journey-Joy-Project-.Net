using JourneyJoy.Entities;

namespace JourneyJoy.DAL.Abstract
{
    public interface IDestinationDAL : IGenericDAL<Destination>
    {
        Task<IEnumerable<Destination>> GetLastFourDestinationAsync();
    }
}
