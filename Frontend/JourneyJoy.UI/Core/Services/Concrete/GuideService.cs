using JourneyJoy.UI.Core.Dtos.GetResponseDtos;
using JourneyJoy.UI.Core.Dtos.GuideDtos;
using JourneyJoy.UI.Core.Helper;
using JourneyJoy.UI.Core.Services.Abstract;

namespace JourneyJoy.UI.Core.Services.Concrete
{
    public class GuideService(HttpClientHelper httpClientHelper) : GenericService<CreateGuideDto, UpdateGuideDto, ResultGuideDto, int>(httpClientHelper), IGuideService
    {
        private readonly HttpClientHelper _httpClientHelper = httpClientHelper;
        private HttpClient CreateClient() => _httpClientHelper.CreateClient();
        public async Task<GetApiResponseDto<string>> ChangeStatusByIdAsync(int id)
        {
            var client = CreateClient();
            var guideResponse = await GetByIdAsync(id, "guides");
            var guide = guideResponse.Data;
            var response = await client.PutAsJsonAsync($"Guides/ChangeStatus?id={id}",guide);
            return await HandleResponse<string>(response);
        }

        public async Task<GetApiResponseDto<IEnumerable<ResultGuideDto>>> GetGuidesByStatuesTrue()
        {
            var client = CreateClient();
            var response = await client.GetAsync("guides/active");
            return await HandleResponse<IEnumerable<ResultGuideDto>>(response);
        }
    }
}
