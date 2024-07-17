using JourneyJoy.UI.Core.Dtos.CommentDtos;
using JourneyJoy.UI.Core.Dtos.GetResponseDtos;

namespace JourneyJoy.UI.Core.Services.Abstract
{
    public interface ICommentService : IGenericService<CreateCommentDto, UpdateCommentDto, ResultCommentDto, int>
    {
        Task<GetApiResponseDto<IEnumerable<ResultCommentDto>>> GetCommentsByDestinationId(int id);
    }
}
