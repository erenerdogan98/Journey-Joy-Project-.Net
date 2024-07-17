namespace JourneyJoy.UI.Core.Services.Abstract
{
    public interface ITokenService
    {
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}
