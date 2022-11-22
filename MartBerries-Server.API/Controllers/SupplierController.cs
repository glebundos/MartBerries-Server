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
    public class SupplierController : ApiControllerBase
    {
        public SupplierController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<List<Supplier>>> Get()
        {
            return Single(await QueryAsync(new GetAllSupplierQuery()));

            /*return await Task.FromResult(new List<Supplier>
            {
                new Supplier { Name = "TestSamsung" }
            });
            */
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> Create([FromBody] CreateSupplierCommand command)
        {
            return await CommandAsync(command);
        }
    }
}
