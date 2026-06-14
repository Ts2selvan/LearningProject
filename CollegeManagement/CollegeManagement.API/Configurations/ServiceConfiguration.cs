using CollegeManagement.API.Helpers;
using CollegeManagement.API.Repository;
using CollegeManagement.API.Repository.Interfaces;
using CollegeManagement.API.Services;
using CollegeManagement.API.Services.Interfaces;

namespace CollegeManagement.API.Configurations
{
    public static class ServiceConfiguration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // Register services and repositories

            // --- Register Services ---
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICollegeService, CollegeService>();

            // --- Register Repositories ---
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICollegeRepository, CollegeRepository>();

            
            services.AddScoped<JwtTokenGenerator>();

        }
    }
}
