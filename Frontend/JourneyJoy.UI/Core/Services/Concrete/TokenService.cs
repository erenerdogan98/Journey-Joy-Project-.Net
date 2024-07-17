using JourneyJoy.UI.Core.Helper;
using JourneyJoy.UI.Core.Services.Abstract;
using System.Net.Http.Headers;

namespace JourneyJoy.UI.Core.Services.Concrete
{
    public class TokenService(HttpClientHelper httpClientFactory, IHttpContextAccessor httpContextAccessor) : ITokenService
    {
        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {

            var accessToken = httpContextAccessor.HttpContext.Session.GetString("AccessToken");
            if (!string.IsNullOrEmpty(accessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var client = httpClientFactory.CreateClient();
            return await client.SendAsync(request);
        }
    }
}
