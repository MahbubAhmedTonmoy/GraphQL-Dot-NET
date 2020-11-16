using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GQL_client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GQLController : ControllerBase
    {
        

        private readonly ILogger<GQLController> _logger;

        public GQLController(ILogger<GQLController> logger)
        {
            _logger = logger;
        }

       
    }
}
