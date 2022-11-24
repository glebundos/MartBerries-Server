using MartBerries_Server.API.Controllers.Base;
using MartBerries_Server.Application.Commands;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static MartBerries_Server.Core.Entities.Order;

namespace MartBerries_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiControllerBase
    {
        public OrderController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            return Single(await QueryAsync(new GetOrderListQuery()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Order>> Get(Guid id)
        {
            return Single(await QueryAsync(new GetOrderQuery(id)));
        }

        [HttpGet("{statusId:int}")]
        public async Task<ActionResult<List<Order>>> GetByStatusId(int statusId)
        {
            return Single(await QueryAsync(new GetOrderListQuery(statusId)));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNew([FromBody] CreateNewOrderCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut]
        public async Task<ActionResult<Order>> UpdateStatus([FromBody] UpdateOrderStatusCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut("requestedMoney")]
        public async Task<ActionResult<Order>> UpdateStatus([FromBody] UpdateOrderRequestedMoneyCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpPut("submittedMoney")]
        public async Task<ActionResult<Order>> UpdateStatus([FromBody] UpdateOrderSubmittedMoneyCommand command)
        {
            return await CommandAsync(command);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> Delete([FromBody] DeleteOrderCommand command)
        {
            return await CommandAsync(command);
        }
    }
}
