using System.ComponentModel.DataAnnotations;

namespace JourneyJoy.Entities
{
    public class Destination : IEntityBase
    {   
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public int Day { get; set; } // Day Count
        public int Night { get; set; } // Night Count
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; } 
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public string CoverImage { get; set; }
        public string Details { get; set; }
        public string Image2 { get; set; }
        public DateTime Date { get; set; }

        // relationship with Comment 
        public ICollection<Comment>? Comments { get; set; }
        // relationship with Reservation
        public ICollection<Reservation>? Reservations { get; set; }
        // relationship with Guide
        public int GuideID { get; set; } 
        public virtual Guide? Guide { get; set; }
    }
}
