namespace TestTask.WebApi.ServiceExtension
{
    internal static class ServiceExtension
    {
        public static void SetupWebApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGeteralServices();
            services.AddCorsPolicy();
        }

        private static void AddGeteralServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        private static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Policy", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
        }
    }
}
