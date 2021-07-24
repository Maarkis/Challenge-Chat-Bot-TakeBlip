using ChallengeTakeBlip.Interface;
using ChallengeTakeBlip.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeTakeBlip.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureDependency(this IServiceCollection services)
        {
            //services.AddHttpClient<IRemoteRepositoryService, RemoteRepositoryGithub>()
            //    .SetHandlerLifetime(TimeSpan.FromMinutes(5));
            services.AddTransient<IRemoteRepositoryService, RemoteRepositoryGithubService>();
            return services;
        }
    }
}
