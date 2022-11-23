using MartBerries_Server.API.Controllers.Base;
using MartBerries_Server.Application.Commands;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MartBerries_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierProductController : ApiControllerBase
    {
        public SupplierProductController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<List<SupplierProduct>>> Get()
        {
            return Single(await QueryAsync(new GetAllSupplierProductQuery()));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSupplierProductCommand command)
        {
            return await CommandAsync(command);
        }
    }
}
