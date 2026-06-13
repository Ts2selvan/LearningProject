using CollegeManagement.API.Data;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.API.Configurations
{
    public static class DataBaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CLgDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DevConnection")));
        }
    }
}
