using JourneyJoy.BLL.Abstract;
using JourneyJoy.DTO.CommentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(ICommentService commentService) : BaseController
    {
        // Get All By List 
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetComments()
        {
            var response = await commentService.TGetAllAsync();
            return CreateApiResponse(response);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var response = await commentService.TGetByIdAsync(id);
            return CreateApiResponse(response);
        }

        // Get Comments By Destination Id
        [HttpGet("bydestination")]
        public async Task<IActionResult> GetCommentsByDestinationId(int id)
        {
            var response = await commentService.TGetAllAsync(x => x.DestinationId == id);
            return CreateApiResponse(response);
        }

        // Create 
        // For FromBody attribute , it will check model (also My rules with Fluent Validation)
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto createCommentDto)
        {
            var response = await commentService.TAddAsync(createCommentDto);
            return CreateApiResponse(response);
        }

        // Delete for by Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var response = await commentService.TDeleteAsync(id);
            return CreateApiResponse(response);
        }

        // Update
        [HttpPut]
        public IActionResult UpdateComment([FromBody] UpdateCommentDto updateCommentDto)
        {
            var response = commentService.TUpdate(updateCommentDto);
            return CreateApiResponse(response);
        }
    }
}
