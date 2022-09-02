using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Core.Common;
using TestTask.Core.Validations;

namespace TestTask.Core
{
    public static class StartupSetup
    {
        public static void SetupCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper();
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddFluentValitation(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}