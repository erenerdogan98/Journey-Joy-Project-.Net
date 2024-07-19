using JourneyJoy.UI.Controllers;
using JourneyJoy.UI.Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace JourneyJoy.UI.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/{controller}")]
    public class DestinationController(IDestinationService destinationService) : BaseController
    {
        private readonly string DestinationApiUrl = "Destinations";

        [HttpGet("Destinations")]
        public async Task<IActionResult> Index()
        {
            var response = await destinationService.GetAllAsync(DestinationApiUrl);
            var values = response.Data;
            return HandleErrorResponse(response, "Index", values);
        }
    }
}
