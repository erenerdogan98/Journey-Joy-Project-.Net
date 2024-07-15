using System.ComponentModel.DataAnnotations;

namespace JourneyJoy.Entities
{
    public class Account : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}
