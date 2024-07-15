using Microsoft.AspNetCore.Identity;

namespace JourneyJoy.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole() : base()
        {
        }

        public AppRole(string roleName) : base(roleName)
        {
        }
    }
}
