using MartBerries_Server.API.Controllers.Base;
using MartBerries_Server.Application.Commands;
using MartBerries_Server.Application.Helpers;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MartBerries_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ApiControllerBase
    {
        public SupplierController(IMediator mediator) : base(mediator) { }

        [Authorize(4)]
        [HttpGet]
        public async Task<ActionResult<List<Supplier>>> Get()
        {
            return await QueryAsync(new GetAllSupplierQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSupplierCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> Delete([FromBody] DeleteSupplierCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut]
        public async Task<ActionResult<Supplier>> Update([FromBody] UpdateSupplierCommand command)
        {
            return await CommandAsync(command);
        }
    }
}
