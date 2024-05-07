using MediatR;
using SignSafe.Domain.Entities;

namespace SignSafe.Application.Users.Queries.GetAll
{
    public class GetAllUserQuery : IRequest<List<User>>
    {
    }
}
