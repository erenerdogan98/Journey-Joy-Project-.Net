namespace JourneyJoy.DTO.ReservationDtos
{
    public class CreateReservationDto
    {
        public int PersonCount { get; set; }
        public string Description { get; set; }
        public DateTime ReservationDate { get; set; }
        public int Status { get; set; } 
        public int AppUserId { get; set; }
        public int DestinationId { get; set; }
    }
}
