﻿using MartBerries_Server.API.Controllers.Base;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace MartBerries_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyTransferController : ApiControllerBase
    {
        public MoneyTransferController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<List<MoneyTransfer>>> Get()
        {
            return await QueryAsync(new GetAllMoneyTransferQuery());
        }

        [HttpGet("report")]
        public async Task<ActionResult<bool>> GenerateReport()
        {
            var bytes = await RawQueryAsync(new GenerateMoneyReportQuery());
            return File(bytes, "text/csv");
        }
    }
}
