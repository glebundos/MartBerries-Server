using MartBerries_Server.API.Controllers.Base;
using MartBerries_Server.Application.Commands;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Application.Models;
using MartBerries_Server.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MartBerries_Server.Application.Helpers;
using static MartBerries_Server.Core.Entities.User;

namespace MartBerries_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiControllerBase
    {
        public OrderController(IMediator mediator) : base(mediator) { }

        [Authorize((int)UserRoles.Manager)]
        [HttpGet]
        public async Task<ActionResult<List<OrderResponse>>> Get()
        {
            var user = (User)HttpContext.Items.FirstOrDefault(x => x.Key.ToString() == "User").Value!;
            var roleId = user.UserRoleId;
            return await QueryAsync(new GetOrderListQuery(roleId));
        }

        [Authorize((int)UserRoles.Customer)]
        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<Order>> Get(Guid id)
        {
            return await QueryAsync(new GetOrderQuery(id));
        }

        [Authorize(-1)]
        [HttpGet("{statusId:int}")]
        public async Task<ActionResult<List<OrderResponse>>> GetByStatusId(int statusId)
        {
            var user = (User)HttpContext.Items.FirstOrDefault(x => x.Key.ToString() == "User").Value!;
            var roleId = user.UserRoleId;
            return await QueryAsync(new GetOrderListQuery(statusId, roleId));
        }

        [Authorize((int)UserRoles.Customer)]
        [HttpPost]
        public async Task<ActionResult<Order>> CreateNew([FromBody] CreateNewOrderCommand command)
        {
            return await CommandAsync(command);
        }

        [Authorize(-1)]
        [HttpPut]
        public async Task<ActionResult<Order>> UpdateStatus([FromBody] UpdateOrderStatusCommand command)
        {
            var user = (User)HttpContext.Items.FirstOrDefault(x => x.Key.ToString() == "User").Value!;
            var roleId = user.UserRoleId;
            command.RoleId = roleId;
            return await CommandAsync(command);
        }

        [Authorize((int)UserRoles.Accountant)]
        [HttpPut("requestedMoney")]
        public async Task<ActionResult<Order>> UpdateStatus([FromBody] UpdateOrderRequestedMoneyCommand command)
        {
            return await CommandAsync(command);
        }

        [Authorize((int)UserRoles.Customer)]
        [HttpPut("submittedMoney")]
        public async Task<ActionResult<Order>> UpdateStatus([FromBody] UpdateOrderSubmittedMoneyCommand command)
        {
            return await CommandAsync(command);
        }

        [Authorize((int)UserRoles.Manager)]
        [HttpDelete]
        public async Task<ActionResult<Guid>> Delete([FromBody] DeleteOrderCommand command)
        {
            return await CommandAsync(command);
        }
    }
}
