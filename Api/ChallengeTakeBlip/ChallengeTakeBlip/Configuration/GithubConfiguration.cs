using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ChallengeTakeBlip.Utils;

namespace ChallengeTakeBlip.Configuration
{
    public static class GithubConfiguration
    {
        public static IServiceCollection ConfigureDependeciesApiGithub(this IServiceCollection services, IConfiguration configuration)
        {
            APIGithub github = new();
            new ConfigureFromConfigurationOptions<APIGithub>(
                configuration.GetSection("ApiGitHub")).Configure(github);
            services.AddSingleton(github);

            return services;
        }
    }
}
