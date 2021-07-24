using ChallengeTakeBlip.Interface;
using ChallengeTakeBlip.Utils;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChallengeTakeBlip.Service
{
    public class RemoteRepositoryGithubService : IRemoteRepositoryService
    {
        private readonly APIGithub _github;
        private readonly GitHubClient _client;

        public RemoteRepositoryGithubService(APIGithub github)
        {
            _github = github;
            _client = DefineClient(_github);
               
        }

        private GitHubClient DefineClient(APIGithub github)
        {
            GitHubClient client = new(new ProductHeaderValue(github.ProductName));
            client.Credentials = new Credentials(github.Token);

            return client;
        }

        public async Task<List<Repository>> GetLastFivePublicRepositoriesCSharp(string username, int amountRepositories = 5)
        {
            IReadOnlyList<Repository> repositories = await _client.Repository.GetAllForUser(username);

            List<Repository> listRepositories = IReadListToList(repositories);

            List<Repository> repositoriesCSHARP = FindAllCSharpLanguageRepositories(listRepositories);

            repositoriesCSHARP = repositoriesCSHARP.OrderBy(f => f.CreatedAt).ToList();

            repositoriesCSHARP = GetFiveRepositories(repositoriesCSHARP, amountRepositories);

            return repositoriesCSHARP;
        }

        private List<Repository> IReadListToList(IReadOnlyList<Repository> repositories)
        {
            List<Repository> listRepositories = new();
            for (int i = 0; i < repositories.Count; i++)
            {
                listRepositories.Add(repositories[i]);
            }

            return listRepositories;
        }

        private List<Repository> FindAllCSharpLanguageRepositories(List<Repository> repositories)
        {
            return repositories.FindAll(repository => repository.Language == "C#");
        }

        private List<Repository> GetFiveRepositories(List<Repository> repositories, int qtdRepository)
        {
            return repositories.Take(qtdRepository).ToList();           
        }
    }
}
