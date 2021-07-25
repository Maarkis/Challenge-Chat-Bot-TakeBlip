using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeTakeBlip.Utils.Response
{
    public class GithubResponse : BaseResponse
    {
        public List<Repository> Repositories { get; set; }
    }
}
