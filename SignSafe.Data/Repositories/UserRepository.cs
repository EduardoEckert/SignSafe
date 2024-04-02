using Microsoft.EntityFrameworkCore;
using SignSafe.Data.Context;
using SignSafe.Domain.Entities;
using SignSafe.Domain.RepositoryInterfaces;

namespace SignSafe.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyContext _dbContext;
        public UserRepository(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _dbContext.Set<User>().AsNoTracking().ToListAsync();
        }
    }
}
