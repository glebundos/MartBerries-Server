using MartBerries_Server.API.Controllers.Base;
using MartBerries_Server.Application.Commands;
using MartBerries_Server.Application.Helpers;
using MartBerries_Server.Application.Models;
using MartBerries_Server.Application.Queries;
using MartBerries_Server.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MartBerries_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        public UserController(IMediator mediator) : base(mediator) { }

        [HttpPost("auth")]
        public async Task<ActionResult<AuthenticateResponse>> Authenticate([FromBody] AuthenticateCommand command)
        {
            return await CommandAsync(command);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await QueryAsync(new GetAllUserQuery());
        }
    }
}
