using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Core.Common;
using TestTask.Core.Inrerfaces.Services;
using TestTask.Core.Services;
using TestTask.Core.Validations;

namespace TestTask.Core
{
    public static class StartupSetup
    {
        public static void SetupCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper();
            services.AddFluentValitation();
            services.AddCustomServices();
        }

        private static void AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApplicationProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void AddFluentValitation(this IServiceCollection services)
        {
            services.AddFluentValidation(
                c => c.RegisterValidatorsFromAssemblyContaining<AddContactValidation>());
        }

        private static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}