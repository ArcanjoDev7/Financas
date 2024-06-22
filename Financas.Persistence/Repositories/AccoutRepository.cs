using Financas.Domain.Models;
using Financas.Infra.Persistence.Repositories.Interfaces;
using Financas.Persistence.Data;
using Financas.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Financas.Infra.Persistence.Repositories
    {
    public class AccoutRepository(AppDbContext context) : RepositoryBase<Account>(context), IAccountRepository
        {
            public async Task<Account?> GetByIdAsync(Guid id)
            {
                return await Context.Account
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            public async Task<Account?> GetByNameAsync(string name)
        {
            return await Context.Account
               .FirstOrDefaultAsync(x => x.Name == name);
        }
    } 
}
