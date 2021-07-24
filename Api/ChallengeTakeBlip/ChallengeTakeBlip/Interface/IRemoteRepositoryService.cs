using Octokit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChallengeTakeBlip.Interface
{
    public interface IRemoteRepositoryService
    {
        Task<List<Repository>> GetLastFivePublicRepositoriesCSharp(string username, int amountRepositories);
    }
}
