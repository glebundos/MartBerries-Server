using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MartBerries_Server.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException();
        }

        protected async Task<ActionResult<TResult>> QueryAsync<TResult>(IRequest<TResult> query)
        {
            try
            {
                return Ok(await _mediator.Send(query));
            }
            catch
            {
                return StatusCode(500);
            }
        }

        protected async Task<ActionResult<TResult>> CommandAsync<TResult>(IRequest<TResult> command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
