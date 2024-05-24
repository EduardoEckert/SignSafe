using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignSafe.Application.Users.Commands.Delete;
using SignSafe.Application.Users.Commands.Insert;
using SignSafe.Application.Users.Commands.Update;
using SignSafe.Application.Users.Queries.Get;
using SignSafe.Application.Users.Queries.GetAll;

namespace SignSafe.Presentation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get-by-filter:paginated")]
        public async Task<IActionResult> GetByFilter([FromQuery] GetUsersByFilterQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] GetUserQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] InsertUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
