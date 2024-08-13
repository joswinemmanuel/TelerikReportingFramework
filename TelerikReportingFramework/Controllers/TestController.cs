using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace TelerikReportingFramework.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public string Get()
        {
            return "Web API is working!";
        }
    }
}