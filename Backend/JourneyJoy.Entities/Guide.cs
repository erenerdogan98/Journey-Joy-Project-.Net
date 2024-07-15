using System.ComponentModel.DataAnnotations;

namespace JourneyJoy.Entities
{
    public class Guide : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string Image { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string Description2 { get; set; }
        public string GuideListImage { get; set; }
        public bool Status { get; set; }
        // relationship with Destination
        public ICollection<Destination> Destinations { get; set; }
    }
}
