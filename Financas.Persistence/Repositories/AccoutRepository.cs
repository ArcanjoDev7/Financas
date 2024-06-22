using Financas.Domain.Models;
using Financas.Infra.Persistence.Repositories.Interfaces;

namespace Financas.Infra.Persistence.Repositories
    {
        public class AccoutRepository(AppDbContext context) : RepositoryBase<Account>(context), IAccountRepository
        {
            public async Task<Account?> GetByIdAsync(Guid id)
            {
                return await Context.Accounts
                    .FirstOrDefaultAsync(t => t.Id == id);
            }
            public async Task<Account?> GetAsync(string name)
        {
            return await Context.Accounts
               .FirstOrDefaultAsync(x => x.Name == name);
        }
            public async Task<Account?> CreateAsync(Account account)
        {
            await Context.Accounts.AddAsync(account);
            await Context.SaveChangesAsync();
            return account;
        }
    }
}
