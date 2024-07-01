using Financas.Domain.Models;
using Financas.Persistence.Data;
using Financas.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Financas.Persistence.Repositories
{
    public class ExpensesRepository(AppDbContext context) : RepositoryBase<Expenses>(context), IExpensesRepository
    {
        public async Task<bool> CategoriesExistAsync(string categories)
        {
            return await Context.Expenses
                .AsNoTracking()
                .Select(x => x.Categories)
                .AnyAsync(x => x == categories);
        }
        public async Task<List<Expenses>> GetAsNoTrackingAsync(string categories)
        {
            return await Context.Expenses
                .AsNoTracking()
                .Where(e => e.Categories == categories)
                .ToListAsync();
        }
        public async Task<decimal> GetTotalExpensesAsync(DateTime startDate, DateTime endDate)
        {
            return await Context.Expenses
               .AsNoTracking()
               .Where(e => e.Date >= startDate && e.Date <= endDate)
               .SumAsync(e => e.Value);
        }
    }
}
