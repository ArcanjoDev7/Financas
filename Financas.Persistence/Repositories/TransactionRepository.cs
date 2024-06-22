using Financas.Domain.Models;
using Financas.Infra.Persistence.Repositories.Interfaces;
using Financas.Persistence.Data;
using Financas.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Financas.Infra.Persistence.Repositories
{
    public class TransactionRepository(AppDbContext context) : RepositoryBase<Transaction>(context), ITransactionRepository
    {
        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await Context.Transaction
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
