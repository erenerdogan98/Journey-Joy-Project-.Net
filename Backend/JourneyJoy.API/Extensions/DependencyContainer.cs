using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog.Events;
using Serilog;
using JourneyJoy.BLL.Helper;
using JourneyJoy.BLL.Validations.CreateValidationRules;
using FluentValidation;
using FluentValidation.AspNetCore;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.BLL.Concrete;
using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Repositories.EFRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JourneyJoy.API.Extensions
{
    public static class DependencyContainer
    {
        // To Manage our dependencies here ..
        public static void ConfigureMyServices(this IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Identity 
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Serilog
            #region Serilog configurations
            Log.Logger = new LoggerConfiguration()
.MinimumLevel.Debug()
.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
.Enrich.FromLogContext()
.WriteTo.Console()
.WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Hour)
.CreateLogger();

            hostBuilder.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .WriteTo.Console());

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog(dispose: true);
            });
            #endregion

            // AutoMapper 
            services.AddAutoMapper(typeof(MapProfile));
            // Fluent Validation
            services.AddValidatorsFromAssemblyContaining<CreateAboutValidator>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            #region Services
            #region DAL
            services.AddScoped<IAboutDAL, EFAboutRepository>();
            services.AddScoped<IAccountDAL, EFAccountRepository>();
            services.AddScoped<IAnnouncementDAL, EFAnnouncementRepository>();
            services.AddScoped<ICommentDAL, EFCommentRepository>();
            services.AddScoped<IContactDAL, EFContactRepository>();
            services.AddScoped<IDestinationDAL, EFDestinationRepository>();
            services.AddScoped<IFeatureDAL, EFFeatureRepository>();
            services.AddScoped<IGetContactDAL, EFGetContactRepository>();
            services.AddScoped<IGuideDAL, EFGuideRepository>();
            services.AddScoped<INewsLetterDAL, EFNewsLetterRepository>();
            services.AddScoped<IReservationDAL, EFReservationRepository>();
            services.AddScoped<ISubAboutDAL, EFSubAboutRepository>();
            services.AddScoped<ITestimonialDAL, EFTestimonialRepository>();
            services.AddScoped<IAuthDAL, EFAuthRepository>();

            #endregion

            #region BLL
            services.AddScoped<IAboutSerivce, AboutManager>();
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IFeatureService, FeatureManager>();
            services.AddScoped<IGetContactService, GetContactManager>();
            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<INewsLetterService, NewsLetterManager>();
            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<ISubAboutService, SubAboutManager>();
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddTransient<IExcelService, ExcelManager>();
            services.AddTransient<IEmailService, EmailManager>();
            #endregion
            #endregion

            #region Authentication with JWT
            // Jwt
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            });

            services.AddAuthorizationBuilder()
                .SetDefaultPolicy(new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build())
                .AddPolicy("Admin", policy =>
                policy.RequireRole("Admin")
                      .RequireAuthenticatedUser())
                .AddPolicy("Member", policy =>
               policy.RequireRole("Member")
                     .RequireAuthenticatedUser());

            // Adding authantication to Swagger UI
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            #endregion
        }
    }
}
