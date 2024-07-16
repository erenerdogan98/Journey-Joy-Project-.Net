using JourneyJoy.API.Helper;
using JourneyJoy.DTO.ServiceResponseDtos;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult CreateApiResponse<T>(ApiResponseDto<T> response)
        {
            return ApiResponseHelper.CreateApiResponse(response);
        }
    }
}
