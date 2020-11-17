using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GQL_client.Consumer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GQL_client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GQLController : ControllerBase
    {

        private readonly OwnerConsumer ownerConsumer;
        private readonly ILogger<GQLController> _logger;

        public GQLController(ILogger<GQLController> logger, OwnerConsumer ownerConsumer)
        {
            _logger = logger;
            this.ownerConsumer = ownerConsumer;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var owners = await ownerConsumer.GetAllOwners();
            return Ok(owners);
        }

       
    }
}
