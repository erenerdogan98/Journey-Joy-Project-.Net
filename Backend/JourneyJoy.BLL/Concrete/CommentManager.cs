using AutoMapper;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DTO.CommentDtos;
using JourneyJoy.Entities;

namespace JourneyJoy.BLL.Concrete
{
    public class CommentManager(ICommentDAL CommentDAL, IMapper mapper) : GenericManager<Comment, CreateCommentDto, UpdateCommentDto, ResultCommentDto>(CommentDAL, mapper), ICommentService
    {
    }
}
