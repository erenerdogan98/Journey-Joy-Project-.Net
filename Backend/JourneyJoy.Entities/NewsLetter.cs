using System.ComponentModel.DataAnnotations;

namespace JourneyJoy.Entities
{
    public class NewsLetter : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Mail { get; set; }
    }
}
