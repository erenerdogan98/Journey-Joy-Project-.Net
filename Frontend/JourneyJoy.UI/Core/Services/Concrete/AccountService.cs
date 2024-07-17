using JourneyJoy.UI.Core.Dtos.AccountDtos;
using JourneyJoy.UI.Core.Dtos.GetResponseDtos;
using JourneyJoy.UI.Core.Helper;
using JourneyJoy.UI.Core.Services.Abstract;

namespace JourneyJoy.UI.Core.Services.Concrete
{
    public class AccountService(HttpClientHelper httpClient) : GenericService<CreateAccountDto, UpdateAccountDto, ResultAccountDto, int>(httpClient), IAccountService
    {
        private readonly HttpClientHelper _httpClientHelper = httpClient;
        private HttpClient CreateClient() => _httpClientHelper.CreateClient();
        public async Task<GetApiResponseDto<string>> MultiUpdate(IEnumerable<UpdateAccountDto> updateAccountDto)
        {
            var client = CreateClient();
            var response = await client.PutAsJsonAsync("accounts/multiupdate",updateAccountDto);
            return await HandleResponse<string>(response);
        }
    }
}
