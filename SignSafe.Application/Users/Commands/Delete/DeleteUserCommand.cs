using MediatR;

namespace SignSafe.Application.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public long UserId { get; set; }
    }
}
