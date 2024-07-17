using JourneyJoy.UI.Core.Dtos.CommentDtos;
using JourneyJoy.UI.Core.Dtos.GetResponseDtos;
using JourneyJoy.UI.Core.Helper;
using JourneyJoy.UI.Core.Services.Abstract;

namespace JourneyJoy.UI.Core.Services.Concrete
{
    public class CommentService(HttpClientHelper httpClientHelper) : GenericService<CreateCommentDto, UpdateCommentDto, ResultCommentDto, int>(httpClientHelper), ICommentService
    {
        private readonly HttpClientHelper _httpClientHelper = httpClientHelper;
        private HttpClient CreateClient() => _httpClientHelper.CreateClient();
        public async Task<GetApiResponseDto<IEnumerable<ResultCommentDto>>> GetCommentsByDestinationId(int id)
        {
            var client = CreateClient();
            var response = await client.GetAsync($"Comments/bydestination?id={id}");
            return await HandleResponse<IEnumerable<ResultCommentDto>>(response);
        }
    }
}
