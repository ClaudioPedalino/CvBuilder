using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvBuilder.Core.Middlewares.LoggingReqRes
{
    public class LoggedResponse
    {
        public int StatusCode { get; init; }
        public string Body { get; init; }
    }
}
