using JourneyJoy.Entities;
using Microsoft.AspNetCore.Identity;

namespace JourneyJoy.DAL.Abstract
{
    public interface IAuthDAL
    {
        Task<AppUser> GetUserByEmailAsync(string email);
        Task<AppUser> GetUserByUserNameAsync(string userName);
        Task<bool> CreateUserAsync(AppUser user, string password);
        Task AddUserToRoleAsync(AppUser user, string role);
        Task<bool> CheckPasswordAsync(AppUser user, string password);
        Task<bool> GetRoleNameAsync(string roleName);
        Task<bool> CreateRoleNameAsync(string roleName);
        Task<AppUser> GetUserByIdAsync(int id);
        Task<IList<string>> GetUserRolesAsync(AppUser user);
        Task<SignInResult> SignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        bool IsEmailUnique(string email);
        bool IsUserNameUnique(string username);
        Task SignOutAsync();
        Task<bool> EditProfile(AppUser user);
        Task SaveChangesAsync();
        Task<int> GetUsersCount();
        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task<bool> DeleteUser(AppUser appUser);
    }
}
