using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JourneyJoy.DAL.Repositories.EFRepositories
{
    public class EFAuthRepository(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, AppDbContext appDbContext) : IAuthDAL
    {
        public async Task AddUserToRoleAsync(AppUser user, string role) => await userManager.AddToRoleAsync(user, role);

        public async Task<bool> CheckPasswordAsync(AppUser user, string password) => await userManager.CheckPasswordAsync(user, password);

        public async Task<bool> CreateUserAsync(AppUser user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async Task<bool> GetRoleNameAsync(string roleName)
        {
            var result = await roleManager.FindByNameAsync(roleName);
            return result == null;
        }

        public async Task<AppUser> GetUserByEmailAsync(string email) => await userManager.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<IList<string>> GetUserRolesAsync(AppUser user) => await userManager.GetRolesAsync(user);

        public async Task<bool> CreateRoleNameAsync(string roleName)
        {
            var result = await roleManager.CreateAsync(new AppRole { Name = roleName });
            return result.Succeeded;
        }
        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AppUser> GetUserByUserNameAsync(string userName) => await userManager.Users.FirstOrDefaultAsync(x => x.UserName == userName);

        public async Task<SignInResult> SignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return await signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }

        public async Task SignOutAsync() => await signInManager.SignOutAsync();

        public bool IsEmailUnique(string email)
        {
            var user = appDbContext.Users.FirstOrDefault(x => x.Email == email);
            return user == null;
        }

        public bool IsUserNameUnique(string username)
        {
            var user = appDbContext.Users.FirstOrDefault(x => x.UserName == username);
            return user == null;
        }

        public async Task<bool> EditProfile(AppUser user)
        {
            var result = await userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<AppUser> GetUserByIdAsync(int id) => await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<int> GetUsersCount() => await userManager.Users.CountAsync();

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync() => await userManager.Users.ToListAsync();

        public async Task<bool> DeleteUser(AppUser user) 
        {
            var result = await userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }

}
