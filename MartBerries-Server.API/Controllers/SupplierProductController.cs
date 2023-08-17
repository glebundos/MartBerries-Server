using MartBerries_Server.API.Controllers.Base;
using MartBerries_Server.Application.Commands;
using MartBerries_Server.Application.Helpers;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static MartBerries_Server.Core.Entities.User;

namespace MartBerries_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierProductController : ApiControllerBase
    {
        public SupplierProductController(IMediator mediator) : base(mediator) { }

        [Authorize((int)UserRoles.Admin)]
        [HttpGet]
        public async Task<ActionResult<List<SupplierProduct>>> Get()
        {
            return await QueryAsync(new GetAllSupplierProductQuery());
        }

        [Authorize((int)UserRoles.Admin)]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSupplierProductCommand command)
        {
            return await CommandAsync(command);
        }

        [Authorize((int)UserRoles.Admin)]
        [HttpDelete]
        public async Task<ActionResult<Guid>> Delete([FromBody] DeleteSupplierProductCommand command) 
        {
            return await CommandAsync(command); 
        }

        [Authorize((int)UserRoles.Admin)]
        [HttpPut]
        public async Task<ActionResult<SupplierProduct>> Update([FromBody] UpdateSupplierProductCommand command)
        {
            return await CommandAsync(command);
        }

        [Authorize((int)UserRoles.SupplierManager)]
        [HttpPost("buy")]
        public async Task<ActionResult<bool>> BuyProduct([FromBody] BuyProductCommand command)
        {
            return await CommandAsync(command);
        }
    }
}
