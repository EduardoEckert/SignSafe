using MediatR;
using SignSafe.Domain.Entities;

namespace SignSafe.Application.Users.Queries.Get
{
    public class GetUserQuery : IRequest<User>
    {
        public long UserId { get; set; }
    }
}
