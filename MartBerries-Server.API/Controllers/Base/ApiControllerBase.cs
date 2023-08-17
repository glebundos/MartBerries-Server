﻿using MartBerries_Server.Application.Helpers;
using MartBerries_Server.Application.Helpers.Exceptions;
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
            catch (RightsException ex)
            {
                return new JsonResult(new { message = ex.Message }) { StatusCode = CustomStatusCodes.Status452NotEnoughRights };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        protected async Task<ActionResult<TResult>> CommandAsync<TResult>(IRequest<TResult> command)
        {
            try
            {
                return Ok(await _mediator.Send(command));
            }
            catch (RightsException ex)
            {
                return new JsonResult(new { message = ex.Message }) { StatusCode = CustomStatusCodes.Status452NotEnoughRights };
            }
            catch (Exception ex)
            {
                return new JsonResult(new { message = ex.Message }) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        protected async Task<TResult> RawQueryAsync<TResult>(IRequest<TResult> query)
        {
            try
            {
                return await _mediator.Send(query);
            }
            catch
            {
                return default!;
            }
        }
    }
}
