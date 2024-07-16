using JourneyJoy.DTO.ReservationDtos;

namespace JourneyJoy.BLL.Abstract
{
    public interface IReservationService : IGenericService<CreateReservationDto, UpdateReservationDto, ResultReservationDto>
    {
    }
}
