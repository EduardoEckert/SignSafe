using Microsoft.EntityFrameworkCore;
using SignSafe.Data.Context;
using SignSafe.Domain.Entities;
using SignSafe.Domain.RepositoryInterfaces;

namespace SignSafe.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MyContext context) : base(context)
        {
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _context.Set<User>().ToListAsync();
        }
    }
}
