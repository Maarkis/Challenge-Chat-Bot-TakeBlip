using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeTakeBlip.Utils.Response
{
    public class BaseResponse
    {
        public bool Successful = false;
        public string Message { get; set; }
    }
}
