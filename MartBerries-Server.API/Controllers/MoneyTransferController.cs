using MartBerries_Server.API.Controllers.Base;
using MartBerries_Server.Application.Helpers;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using static MartBerries_Server.Core.Entities.User;

namespace MartBerries_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyTransferController : ApiControllerBase
    {
        public MoneyTransferController(IMediator mediator) : base(mediator) { }

        [Authorize((int)UserRoles.Accountant)]
        [HttpGet]
        public async Task<ActionResult<List<MoneyTransfer>>> Get()
        {
            return await QueryAsync(new GetAllMoneyTransferQuery());
        }

        [Authorize((int)UserRoles.Accountant)]
        [HttpGet("report")]
        public async Task<ActionResult<bool>> GenerateReport()
        {
            var bytes = await RawQueryAsync(new GenerateMoneyReportQuery());
            return File(bytes, "text/csv");
        }
    }
}
