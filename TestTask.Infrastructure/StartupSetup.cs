using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Core.Inrerfaces.Repisitories;
using TestTask.Infrastructure.Data;
using TestTask.Infrastructure.Data.Repositories;

namespace TestTask.Infrastructure
{
    public static class StartupSetup
    {
        public static void SetupInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTestTaskDbContext(configuration);
            services.AddRepositories();
        }

        private static void AddTestTaskDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<TestTaskDbContext>(x =>
                    x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        }
    }
}
