using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SignSafe.Application.Users.Commands.Delete;
using SignSafe.Application.Users.Commands.Insert;
using SignSafe.Application.Users.Commands.Update;
using SignSafe.Application.Users.Commands.UpdateRole;
using SignSafe.Application.Users.Queries.Get;
using SignSafe.Application.Users.Queries.GetAll;
using SignSafe.Application.Users.Queries.Login;

namespace SignSafe.Presentation.Controllers
{
    [Route("api/users")]
    [Authorize]
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
        [Route("login")]
        public async Task<IActionResult> Login([FromQuery] LoginUserQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet]
        [Route("get-by-filter:paginated")]
        public async Task<IActionResult> GetByFilter([FromQuery] GetUsersByFilterQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get([FromQuery] GetUserQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert([FromBody] InsertUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [Route("update-roles")]
        public async Task<IActionResult> UpdateRoles([FromQuery] UpdateUserRolesCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
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
