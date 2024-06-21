using Financas.Domain.Models;
using Financas.Persistence.Data;
using Financas.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Financas.Persistence.Repositories
{
    public class UserRepository(AppDbContext context) : RepositoryBase<User>(context), IUserRepository
    {
        public async Task<bool> EmailExistAsync(string email)
        {
            return await Context.Users
                .AsNoTracking()
                .Select(x => x.Email)
                .AnyAsync(x => x == email);
        }
        public async Task<User?> GetAsNoTrackingAsync(string email)
        {
            return await Context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<User?> GetAsync(string email)
        {
            return await Context.Users
               .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
