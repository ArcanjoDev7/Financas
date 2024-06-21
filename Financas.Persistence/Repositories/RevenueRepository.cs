using Financas.Domain.Models;
using Financas.Persistence.Data;
using Financas.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Financas.Persistence.Repositories
{
    public class RevenueRepository(AppDbContext context) : RepositoryBase<Revenue>(context), IRevenueRepository
    {
        public async Task<IEnumerable<Revenue>> GetByCategoria(string caregories)
        {
            return await Context.Revenue
                .AsNoTracking()
                .Where(e => e.Categories == caregories)
                .ToListAsync();
        }

        public async Task<IEnumerable<Revenue>> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return await Context.Revenue
                .AsNoTracking()
                .Where(e => e.Data >= startDate && e.Data <= endDate)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate)
        {
            return await Context.Revenue
               .Where(e => e.Data >= startDate && e.Data <= endDate)
               .SumAsync(e => e.value);
        }
    }
}
