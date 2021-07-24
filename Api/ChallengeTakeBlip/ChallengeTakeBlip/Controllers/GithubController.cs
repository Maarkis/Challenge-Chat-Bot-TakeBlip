using ChallengeTakeBlip.Interface;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeTakeBlip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        public readonly IRemoteRepositoryService _remoteRepositoryService;
        public GithubController(IRemoteRepositoryService remoteRepositoryService )
        {
            _remoteRepositoryService = remoteRepositoryService;
        }

        

        [HttpGet]
        public async Task<ActionResult> GetLastFivePublicRepositoriesCSharp(string username, int amountRepositories)
        {
            var result = await _remoteRepositoryService.GetLastFivePublicRepositoriesCSharp(username, amountRepositories);
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}
