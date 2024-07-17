using JourneyJoy.Core.Dtos.ReservationDtos;
using JourneyJoy.UI.Core.Dtos.GetResponseDtos;

namespace JourneyJoy.UI.Core.Services.Abstract
{
    public interface IReservationService : IGenericService<CreateReservationDto, UpdateReservationDto, ResultReservationDto, int>
    {
        Task<GetApiResponseDto<IEnumerable<ResultReservationDto>>> GetAprrovedAsync();
        Task<GetApiResponseDto<IEnumerable<ResultReservationDto>>> GetAprrovedByIdAsync(int id);
        Task<GetApiResponseDto<IEnumerable<ResultReservationDto>>> GetPendingAprrovalAsync();
        Task<GetApiResponseDto<IEnumerable<ResultReservationDto>>> GetPendingAprrovalByIdAsync(int id);
    }
}
