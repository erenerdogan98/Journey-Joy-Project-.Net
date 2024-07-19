using JourneyJoy.Core.Dtos.ReservationDtos;

namespace JourneyJoy.UI.Areas.Member.Models
{
    public class ReservationResultModel
    {
        public string DestinationCity { get; set; }
        public string FullName { get; set; }
        public ResultReservationDto ResultReservationDto { get; set; }
    }
}
