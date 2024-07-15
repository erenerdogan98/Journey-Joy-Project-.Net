using System.ComponentModel.DataAnnotations;

namespace JourneyJoy.Entities
{
    public class Contact : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }  
        public string Mail { get; set; }
        public string Adress { get; set; } 
        public string Phone { get; set; } 
        public string MapLocation { get; set; } 
        public bool Status { get; set; }
    }
}
