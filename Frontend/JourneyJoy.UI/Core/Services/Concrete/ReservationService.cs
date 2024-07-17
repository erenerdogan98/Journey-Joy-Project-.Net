using JourneyJoy.Core.Dtos.ReservationDtos;
using JourneyJoy.UI.Core.Dtos.GetResponseDtos;
using JourneyJoy.UI.Core.Helper;
using JourneyJoy.UI.Core.Services.Abstract;

namespace JourneyJoy.UI.Core.Services.Concrete
{
    public class ReservationService(HttpClientHelper clientHelper) : GenericService<CreateReservationDto, UpdateReservationDto, ResultReservationDto, int>(clientHelper), IReservationService
    {
        private readonly HttpClientHelper _clientHelper = clientHelper;
        private HttpClient CreateClient() => _clientHelper.CreateClient();
        public async Task<GetApiResponseDto<IEnumerable<ResultReservationDto>>> GetAprrovedAsync()
        {
            var client = CreateClient();
            var response = await client.GetAsync("Reservations/ApprovedReservations");
            return await HandleResponse<IEnumerable<ResultReservationDto>>(response);
        }

        public async Task<GetApiResponseDto<IEnumerable<ResultReservationDto>>> GetPendingAprrovalAsync()
        {
            var client = CreateClient();
            var response = await client.GetAsync("Reservations/PendingApproval");
            return await HandleResponse<IEnumerable<ResultReservationDto>>(response);
        }

        public async Task<GetApiResponseDto<IEnumerable<ResultReservationDto>>> GetAprrovedByIdAsync(int id)
        {
            var client = CreateClient();
            var response = await client.GetAsync($"Reservations/ApprovedReservations/{id}");
            return await HandleResponse<IEnumerable<ResultReservationDto>>(response);
        }

        public async Task<GetApiResponseDto<IEnumerable<ResultReservationDto>>> GetPendingAprrovalByIdAsync(int id)
        {
            var client = CreateClient();
            var response = await client.GetAsync($"Reservations/PendingApproval/{id}");
            return await HandleResponse<IEnumerable<ResultReservationDto>>(response);
        }
    }
}
