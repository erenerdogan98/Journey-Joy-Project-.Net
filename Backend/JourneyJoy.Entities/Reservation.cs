using System.ComponentModel.DataAnnotations;

namespace JourneyJoy.Entities
{
    public class Reservation : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public int PersonCount { get; set; } 
        public string Description { get; set; }
        public DateTime ReservationDate { get; set; }
        public int Status { get; set; } // instead of enums , using int 

        // Relationship with AppUser
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        // Relationship with Destination
        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; }
    }
}
