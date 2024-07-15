using System.ComponentModel.DataAnnotations;

namespace JourneyJoy.Entities
{

    public class Testimonial : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Client { get; set; }
        public string Comment { get; set; } 
        public string ClientImage { get; set; } 
        public bool Status { get; set; } 
    }
}

