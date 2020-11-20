using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GQL_client.Consumer;
using GQL_client.GraphQL.GraphQLTypes;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(Guid id)
        {
            var owner = await ownerConsumer.GetOwnerById(id);
            return Ok(owner);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OwnerInput ownerInput)
        {
            var create = await ownerConsumer.CreateOwner(ownerInput);
            return Ok(create);
        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateOwner(Guid Id, OwnerInput ownerInput)
        {
            var update = await ownerConsumer.UpdateOwner(Id, ownerInput);
            return Ok(update);
        }
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> DeleteOwner(Guid Id)
        {
            var delete = await ownerConsumer.DeleteOwner(Id);
            return Ok(delete);
        }
    }
}
