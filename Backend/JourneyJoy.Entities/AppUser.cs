using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JourneyJoy.Entities
{
    public class AppUser : IdentityUser<int>, IEntityBase
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        [NotMapped]
        public IList<string> Roles { get; set; }
        // relation with Reservation
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
