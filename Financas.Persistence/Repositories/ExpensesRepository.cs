using Financas.Domain.Models;
using Financas.Persistence.Data;
using Financas.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Financas.Persistence.Repositories
{
    public class ExpensesRepository(AppDbContext context) : RepositoryBase<Expenses>(context), IExpensesRepository
    {
        public async Task<IEnumerable<Expenses>> GetByCategoria(string categories)
        {
            return await Context.Expenses
                .AsNoTracking()
                .Where(e => e.Categories == categories)
                .ToListAsync();
        }

        public async Task<IEnumerable<Expenses>> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return await Context.Expenses
                .AsNoTracking()
                .Where(e => e.Data >= startDate && e.Data <= endDate)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalExpensesByDateRange(DateTime startDate, DateTime endDate)
        {
            return await Context.Expenses
               .Where(e => e.Data >= startDate && e.Data <= endDate)
               .SumAsync(e => e.value);
        }
    }
}
