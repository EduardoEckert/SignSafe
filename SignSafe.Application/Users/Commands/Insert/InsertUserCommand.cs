using MediatR;
using SignSafe.Domain.Dtos.Users;

namespace SignSafe.Application.Users.Commands.Insert
{
    public class InsertUserCommand : IRequest<Unit>
    {
        public required UserDto UserDto { get; set; }
    }
}
