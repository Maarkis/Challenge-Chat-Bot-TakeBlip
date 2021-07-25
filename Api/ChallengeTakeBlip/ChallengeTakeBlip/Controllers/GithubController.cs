using ChallengeTakeBlip.Interface;
using ChallengeTakeBlip.Utils.Response;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using System;
using System.Collections.Generic;
using System.Net;
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
        public async Task<ActionResult> GetLastFivePublicRepositoriesCSharp(string username, int amountRepositories = 5)
        {
            try
            {
                List<Repository> result = await _remoteRepositoryService.GetLastFivePublicRepositoriesCSharp(username, amountRepositories);
                if (result == null)
                {
                    return NotFound(new BaseResponse { Message = "Não encontrado." });
                }

                return Ok(new GithubResponse { Message = "Encontrado com sucesso.", Successful = true, Repositories = result });
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
          
        }

    }
}
