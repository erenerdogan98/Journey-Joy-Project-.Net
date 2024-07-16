using JourneyJoy.DTO.ServiceResponseDtos;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace JourneyJoy.API.Helper
{
    public class ApiResponseHelper
    {
        public static IActionResult CreateApiResponse<T>(ApiResponseDto<T> response)
        {
            if (response.Success)
                return new OkObjectResult(response);

            Log.Error("Error: {Message}", response.Message);
            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
