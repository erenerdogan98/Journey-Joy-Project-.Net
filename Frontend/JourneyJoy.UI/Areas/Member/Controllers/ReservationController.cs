using JourneyJoy.Core.Dtos.ReservationDtos;
using JourneyJoy.UI.Areas.Member.Models;
using JourneyJoy.UI.Controllers;
using JourneyJoy.UI.Core.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JourneyJoy.UI.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/{controller}")]
    public class ReservationController(IReservationService reservationService,IAuthService authService,IDestinationService destinationService) : BaseController
    {
        [HttpGet("MyCurrentReservations")]
        public async Task<IActionResult> MyCurrentReservations()
        {
            var response = await reservationService.GetPendingAprrovalAsync();
            var values = response.Data;
            var viewModel = new List<ReservationResultModel>();
            foreach(var item in values)
            {
                var destination = await destinationService.GetByIdAsync(item.Id, "destinations");
                var reservationResult = new ReservationResultModel
                {
                    DestinationCity = destination.Data.City,
                    ResultReservationDto = item
                };
                viewModel.Add(reservationResult);
            }
            return HandleErrorResponse(response, "MyCurrentReservations", viewModel);
        }

        [HttpGet("MyApprovedReservations")]
        public async Task<IActionResult> MyApprovedReservations()
        {
            var response = await reservationService.GetAprrovedAsync();
            var values = response.Data;
            var viewModel = new List<ReservationResultModel>();
            foreach (var item in values)
            {
                var destination = await destinationService.GetByIdAsync(item.Id, "destinations");
                var reservationResult = new ReservationResultModel
                {
                    DestinationCity = destination.Data.City,
                    ResultReservationDto = item
                };
                viewModel.Add(reservationResult);
            }
            return HandleErrorResponse(response, "MyApprovalReservations", viewModel);
        }

        [HttpGet("NewReservation")]
        public async Task<IActionResult> NewReservation()
        {
            var destinations = await GetDestinationsAsync();
            int id = int.Parse(authService.GetUserId()); // will change
            var model = new ReservationViewModel
            {
                Destinations = destinations,
                CreateReservationDto = new CreateReservationDto
                {
                    AppUserId = id
                }
            };
            return View(model);
        }

        [HttpPost("NewReservation")]
        public async Task<IActionResult> NewReservation(CreateReservationDto createReservationDto)
        {
            var response = await reservationService.CreateAsync(createReservationDto, "Reservations");
            if (response.Success)
                return RedirectToAction("");
            return Content(response.Message);
        }

        private async Task<List<SelectListItem>> GetDestinationsAsync()
        {
            var response = await destinationService.GetAllAsync("destinations");
            var destinations = response.Data;
            return destinations.Select(c => new SelectListItem
            {
                Text = c.City,
                Value = c.Id.ToString(),
            }).ToList();
        }
    }
}
