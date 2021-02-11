using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GatewayApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayApiController : ControllerBase
    {
        [ReqLimit("Limit")]
        public ActionResult GetMessage()
        {
            return Ok("API Gateway");
        }
    }
}
