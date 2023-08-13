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
    public class ProductController : ApiControllerBase
    {
        public ProductController(IMediator mediator) : base(mediator) { }

        [Authorize(6)]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand command)
        {
            return await CommandAsync(command);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await QueryAsync(new GetAllProductQuery());
        }

        [Authorize(6)]
        [HttpDelete]
        public async Task<ActionResult<Guid>> Delete([FromBody] DeleteProductCommand command)
        {
            return await CommandAsync(command);
        }

        [Authorize(6)]
        [HttpPut]
        public async Task<ActionResult<Product>> Update([FromBody] UpdateProductCommand command)
        {
            return await CommandAsync(command);
        }
    }
}
