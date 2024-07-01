using Financas.Domain.Models;
using Financas.Infra.Persistence.Repositories.Interfaces;
using Financas.Persistence.Data;
using Financas.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Financas.Infra.Persistence.Repositories
{
    public class TransactionRepository(AppDbContext context) : RepositoryBase<Transaction>(context), ITransactionRepository
    {
        public async Task<bool> TransactionExistAsync(string transaction)
        {
            return await Context.Transaction
                .AsNoTracking()
                .Select(x => x.Description)
                .AnyAsync(x => x == transaction);
        }

        public async Task<List<Transaction>> GetAllAsync(Guid userId)
        {
            return await Context.Transaction
                .AsNoTracking()
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }
        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await Context.Transaction
                .FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task<decimal> GetTotalAmountTransactionAsync(DateTime startDate, DateTime endDate)
        {
            return await Context.Transaction
               .AsNoTracking()
               .Where(e => e.Date >= startDate && e.Date <= endDate)
               .SumAsync(e => e.Amount);
        }
    }
}
