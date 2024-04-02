using SignSafe.Domain.Entities;

namespace SignSafe.Domain.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
    }
}
