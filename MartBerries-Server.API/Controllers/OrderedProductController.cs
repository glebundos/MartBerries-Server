using MartBerries_Server.API.Controllers.Base;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MartBerries_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderedProductController : ApiControllerBase
    {
        public OrderedProductController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<List<OrderedProduct>>> Get()
        {
            return await QueryAsync(new GetAllOrderedProductQuery());
        }
    }
}
