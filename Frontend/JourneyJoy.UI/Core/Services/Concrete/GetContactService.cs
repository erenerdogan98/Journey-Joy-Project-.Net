using JourneyJoy.Core.Dtos.GetContactDtos;
using JourneyJoy.UI.Core.Dtos.GetResponseDtos;
using JourneyJoy.UI.Core.Helper;
using JourneyJoy.UI.Core.Services.Abstract;

namespace JourneyJoy.UI.Core.Services.Concrete
{
    public class GetContactService(HttpClientHelper httpClient) : GenericService<CreateGetContactDto, UpdateGetContactDto, ResultGetContactDto, int>(httpClient), IGetContactService
    {
        private readonly HttpClientHelper _httpClientHelper = httpClient;
        private HttpClient CreateClient() => _httpClientHelper.CreateClient();
        public async Task<GetApiResponseDto<IEnumerable<ResultGetContactDto>>> GetListGetContactsByStatusTrue()
        {
            var client = CreateClient();
            var response = await client.GetAsync("getcontacts/Statustrue");
            return await HandleResponse<IEnumerable<ResultGetContactDto>>(response);
        }
    }
}
