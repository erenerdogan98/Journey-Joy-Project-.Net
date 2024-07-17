using JourneyJoy.UI.Core.Dtos.AuthDtos;
using JourneyJoy.UI.Core.Dtos.GetResponseDtos;
using JourneyJoy.UI.Core.Helper;
using JourneyJoy.UI.Core.Services.Abstract;
using Serilog;
using System.Text.Json;

namespace JourneyJoy.UI.Core.Services.Concrete
{
    public class AuthService(HttpClientHelper httpClientHelper, IHttpContextAccessor httpContextAccessor) : IAuthService
    {
        private readonly JsonSerializerOptions _options = new() { PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        private HttpClient CreateClient() => httpClientHelper.CreateClient();

        public string GetUserId() => httpContextAccessor.HttpContext.Session.GetString("UserId");

        public async Task<GetApiResponseDto<LoginServiceResponseDto>> LoginAsync(LoginDto loginViewModel)
        {
            var client = CreateClient();
            var response = await client.PostAsJsonAsync("Auths/SignIn", loginViewModel);
            return await HandleResponse<LoginServiceResponseDto>(response);
		}

        public Task<GetApiResponseDto<string>> Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<GetApiResponseDto<string>> RegisterAsync(RegisterDto registerDto)
        {
            var client = CreateClient();
            var response = await client.PostAsJsonAsync("auths/Register", registerDto);
            if (response.IsSuccessStatusCode)
            {
                return new GetApiResponseDto<string>("Register", true, response.ReasonPhrase, (int)response.StatusCode);
            }
            else
            {
                string errorMessage = await response.Content.ReadAsStringAsync();
                Log.Error("API Response Error: {StatusCode}, Message: {ErrorMessage}", response.StatusCode, errorMessage);

                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    var errorResponse = JsonSerializer.Deserialize<GetApiResponseDto<Dictionary<string, List<string>>>>(errorMessage, _options);
                    return new GetApiResponseDto<string>(default, false, errorResponse?.Message, (int)response.StatusCode, errorResponse?.Errors);
                }

                return new GetApiResponseDto<string>(default, false, response.ReasonPhrase, (int)response.StatusCode);
            }
        }

		private async Task<GetApiResponseDto<T>> HandleResponse<T>(HttpResponseMessage response)
		{
			if (response.IsSuccessStatusCode)
			{
				var result = await response.Content.ReadFromJsonAsync<GetApiResponseDto<T>>(_options);
				// Handle token retrieval and session management
				var loginServiceResponse = result.Data as LoginServiceResponseDto;
				if (loginServiceResponse != null)
				{
					var accessToken = loginServiceResponse.Token;
					httpContextAccessor.HttpContext.Session.SetString("AccessToken", accessToken);
					httpContextAccessor.HttpContext.Session.SetString("UserId", loginServiceResponse.UserInfo.Id.ToString());
				}
				return result with { statusCode = (int)response.StatusCode };
			}
			else
			{
				string errorMessage = await response.Content.ReadAsStringAsync();
				Log.Error("API Response Error: {StatusCode}, Message: {ErrorMessage}", response.StatusCode, errorMessage);

				if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
				{
					var errorResponse = JsonSerializer.Deserialize<GetApiResponseDto<Dictionary<string, List<string>>>>(errorMessage, _options);
					return new GetApiResponseDto<T>(default, false, errorResponse?.Message, (int)response.StatusCode, errorResponse?.Errors);
				}

				return new GetApiResponseDto<T>(default, false, response.ReasonPhrase, (int)response.StatusCode);
			}
		}

        public async Task<GetApiResponseDto<string>> UpdateProfile(UserInfoResult updateProfileDto)
        {
            var client = CreateClient();
            var response = await client.PutAsJsonAsync("Profiles", updateProfileDto);
            return await HandleResponse<string>(response);
        }

        public async Task<GetApiResponseDto<UserInfoResult>> GetUserById(int id)
        {
            var client = CreateClient();
            var response = await client.GetAsync($"Auths/GetUserInfo/{id}");
            return await HandleResponse<UserInfoResult>(response);
        }

        public async Task<GetApiResponseDto<int>> GetUserCount()
        {
            var client = CreateClient();
            var response = await client.GetAsync("Auths/UsersCount");
            return await HandleResponse<int>(response);
        }

        public async Task<GetApiResponseDto<IEnumerable<UserInfoResult>>> GetAllMembers()
        {
            var client = CreateClient();
            var response = await client.GetAsync("auths/GetMembers");
            return await HandleResponse<IEnumerable<UserInfoResult>>(response);
        }

        public async Task<GetApiResponseDto<string>> DeleteMemberAsync(int id)
        {
            var client = CreateClient();
            var response = await client.DeleteAsync($"Auths?id={id}");
            return await HandleResponse<string>(response);
        }
    }
}
