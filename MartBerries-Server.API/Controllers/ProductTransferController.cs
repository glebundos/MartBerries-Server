using MartBerries_Server.API.Controllers.Base;
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
    public class ProductTransferController : ApiControllerBase
    {
        public ProductTransferController(IMediator mediator) : base(mediator) { }

        [Authorize(4)]
        [HttpGet]
        public async Task<ActionResult<List<ProductTransfer>>> Get()
        {
            return await QueryAsync(new GetAllProductTransferQuery());
        }
    }
}
