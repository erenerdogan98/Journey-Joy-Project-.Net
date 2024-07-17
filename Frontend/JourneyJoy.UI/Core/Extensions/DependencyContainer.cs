using JourneyJoy.UI.Core.Helper;
using JourneyJoy.UI.Core.Services.Abstract;
using JourneyJoy.UI.Core.Services.Concrete;
using JourneyJoy.UI.Core.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JourneyJoy.UI.Core.Extensions
{
    public static class DependencyContainer
    {
        public static void ConfigureMyServicesHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ServiceApiSettings>(configuration.GetSection("ServiceApiSettings"));

            var apiValues = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>() ?? throw new ArgumentNullException("ServiceApiSettings");

            services.AddHttpContextAccessor();

			services.AddTransient<Helper.TokenHandler>();

			services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri(apiValues.BaseUrl);
            }).AddHttpMessageHandler<Helper.TokenHandler>();

            // IHttpContextAccessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<HttpClientHelper>();

            // session
            services.AddMemoryCache();
            services.AddSession(options =>
            {
                options.IOTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = configuration["Jwt:Issuer"],
                            ValidAudience = configuration["Jwt:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                        };
                    });

            // Authorization Policy
            services.AddAuthorizationBuilder()
                // Authorization Policy
                                                   .AddPolicy("Admin", policy => policy.RequireRole("Admin"));

            // Session
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddTransient<IDestinationService, DestinationService>();
            services.AddTransient<IGuideService, GuideService>();
            services.AddTransient<IFeatureService, FeatureService>();
            services.AddTransient<ISubAboutService, SubAboutService>();
            services.AddTransient<ITestimonialService, TestimonialService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<IAnnouncementService, AnnouncementService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IGetContactService, GetContactService>();
        }
    }
}
