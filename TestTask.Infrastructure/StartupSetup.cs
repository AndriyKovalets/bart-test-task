using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Infrastructure.Data;

namespace TestTask.Infrastructure
{
    public static class StartupSetup
    {
        public static void SetupInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTestTaskDbContext(configuration);
        }

        public static void AddTestTaskDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<TestTaskDbContext>(x =>
                    x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
