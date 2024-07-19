using JourneyJoy.Core.Dtos.ReservationDtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JourneyJoy.UI.Areas.Member.Models
{
    public class ReservationViewModel
    {
        public List<SelectListItem?> Destinations { get; set; }  
        public CreateReservationDto CreateReservationDto { get; set; }
        public IEnumerable<ResultReservationDto> ResultReservationDto { get; set; }
    }
}
