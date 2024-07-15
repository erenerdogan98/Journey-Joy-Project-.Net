using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JourneyJoy.API.Extensions
{
    public static class DependencyContainer
    {
        // To Manage our dependencies here ..
        public static void ConfigureMyServices(this IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
