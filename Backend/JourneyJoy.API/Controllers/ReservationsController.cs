using JourneyJoy.BLL.Abstract;
using JourneyJoy.DTO.ReservationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JourneyJoy.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController(IReservationService reservationService) : BaseController
    {
        // Get All By List (for authenticated user's reservations)
        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (int.TryParse(userId, out int id))
            {
                if (role == "Admin")
                {
                    var responseA = await reservationService.TGetAllAsync();
                    return CreateApiResponse(responseA);
                }
                var response = await reservationService.TGetAllAsync(x => x.AppUserId == id);
                return CreateApiResponse(response);
            }
            return BadRequest("Invalid user ID");
        }

        // Get By Id (for authenticated user's reservation)
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (int.TryParse(userId, out int userIdInt))
            {
                if (role == "Admin")
                {
                    var responseA = await reservationService.TGetByIdAsync(id);
                    return CreateApiResponse(responseA);
                }
                var response = await reservationService.TGetByIdAsync(id);
                if (response.Data?.AppUserId == userIdInt)
                {
                    return CreateApiResponse(response);
                }
                return Unauthorized("You are not authorized to view this reservation.");
            }
            return BadRequest("Invalid user ID");
        }

        // Get Approved Reservation by App User Id (authenticated user)
        [HttpGet("ApprovedReservations/{id}")]
        public async Task<IActionResult> GetApprovedReservationsById(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (int.TryParse(userId, out int userIdint) && role == "Admin")
            {
                    var responseA = await reservationService.TGetAllAsync(x => x.AppUserId == id && x.Status == 1);
                    return CreateApiResponse(responseA);
            }
            return Unauthorized();
        }
        [Authorize("Admin")]
        [HttpGet("PendingApproval/{id}")]
        public async Task<IActionResult> GetPendingApprovedReservationsById(int id)
        {
                var responseA = await reservationService.TGetAllAsync(x => x.AppUserId == id);
                return CreateApiResponse(responseA);
        }

        // Get Approved Reservation (authenticated user)
        [HttpGet("ApprovedReservations")]
        public async Task<IActionResult> GetApprovedReservations()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (int.TryParse(userId, out int id))
            {
                if (role == "Admin")
                {
                    var responseA = await reservationService.TGetAllAsync(x => x.Status == 1);
                    return CreateApiResponse(responseA);
                }
                var response = await reservationService.TGetAllAsync(x => x.AppUserId == id && x.Status == 1);
                return CreateApiResponse(response);
            }
            return BadRequest("Invalid user ID");
        }

        // Get Approved Reservation (authenticated user)
        [HttpGet("PendingApproval")]
        public async Task<IActionResult> GetPendingApprovedReservations()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (int.TryParse(userId, out int id))
            {
                if (role == "Admin")
                {
                    var responseA = await reservationService.TGetAllAsync(x => x.Status == 2);
                    return CreateApiResponse(responseA);
                }
                var response = await reservationService.TGetAllAsync(x => x.AppUserId == id && x.Status == 2);
                return CreateApiResponse(response);
            }
            return BadRequest("Invalid user ID");
        }


        // Create (authenticated user creating a reservation)
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto createReservationDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(userId, out int id))
            {
                createReservationDto.AppUserId = id;
                var response = await reservationService.TAddAsync(createReservationDto);
                return CreateApiResponse(response);
            }
            return BadRequest("Invalid user ID");
        }

        // Delete for by Id (for authenticated user's reservation)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(userId, out int userIdInt))
            {
                var response = await reservationService.TGetByIdAsync(id);
                if (response.Data?.AppUserId == userIdInt)
                {
                    var deleteResponse = await reservationService.TDeleteAsync(id);
                    return CreateApiResponse(deleteResponse);
                }
                return Unauthorized("You are not authorized to delete this reservation.");
            }
            return BadRequest("Invalid user ID");
        }

        // Update (authenticated user updating a reservation)
        [HttpPut]
        public async Task<IActionResult> UpdateReservation([FromBody] UpdateReservationDto updateReservationDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (int.TryParse(userId, out int id))
            {
                var existingReservation = await reservationService.TGetByIdAsync(updateReservationDto.Id);
                if (existingReservation.Data?.AppUserId == id)
                {
                    var response = reservationService.TUpdate(updateReservationDto);
                    return CreateApiResponse(response);
                }
                return Unauthorized("You are not authorized to update this reservation.");
            }
            return BadRequest("Invalid user ID");
        }
    }
}
