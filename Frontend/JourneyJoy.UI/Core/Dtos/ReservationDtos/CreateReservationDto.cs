using JourneyJoy.UI.Core.Dtos.Enums;

namespace JourneyJoy.Core.Dtos.ReservationDtos
{
    public class CreateReservationDto
    {
        public int Id { get; set; }
        public int PersonCount { get; set; }
        public string Description { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus Status { get; set; } = ReservationStatus.PendingApproval;
        public int AppUserId { get; set; }
        public int DestinationId { get; set; }
    }
}
