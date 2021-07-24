using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration
{
    public static class CORSConfiguration
    {
        public static IServiceCollection ConfigureCORS(this IServiceCollection service)
        {
            service.AddCors(options =>
            {
                options.AddPolicy("AllowCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });

            });
            return service;
        }
    }
}