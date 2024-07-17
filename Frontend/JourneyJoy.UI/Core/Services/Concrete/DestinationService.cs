using JourneyJoy.UI.Core.Dtos.DestinationDtos;
using JourneyJoy.UI.Core.Dtos.GetResponseDtos;
using JourneyJoy.UI.Core.Helper;
using JourneyJoy.UI.Core.Services.Abstract;

namespace JourneyJoy.UI.Core.Services.Concrete
{
    public class DestinationService(HttpClientHelper httpClientHelper) : GenericService<CreateDestinationDto, UpdateDestinationDto, ResultDestinationDto, int>(httpClientHelper), IDestinationService
    {
        private readonly HttpClientHelper _httpClientHelper = httpClientHelper;
        private HttpClient CreateClient() => _httpClientHelper.CreateClient();
        public async Task<GetApiResponseDto<IEnumerable<ResultDestinationDto>>> GetLastFourDestinationsAsync()
        {
            var client = CreateClient();
            var response = await client.GetAsync("destinations/lastfour");
            return await HandleResponse<IEnumerable<ResultDestinationDto>>(response);
        }
    }
}
