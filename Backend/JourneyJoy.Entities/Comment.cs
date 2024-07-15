using System.ComponentModel.DataAnnotations;

namespace JourneyJoy.Entities
{
    public class Comment : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public DateTime Date { get; set; }
        public string? Content { get; set; }
        public bool State { get; set; }
        // relationship 
        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
