using JourneyJoy.DTO.CommentDtos;

namespace JourneyJoy.BLL.Abstract
{
    public interface ICommentService : IGenericService<CreateCommentDto, UpdateCommentDto, ResultCommentDto>
    {
    }
}
