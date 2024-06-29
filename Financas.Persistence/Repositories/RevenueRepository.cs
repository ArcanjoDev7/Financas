using Financas.Domain.Models;
using Financas.Persistence.Data;
using Financas.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Financas.Persistence.Repositories
{
    public class RevenueRepository(AppDbContext context) : RepositoryBase<Revenue>(context), IRevenueRepository
    {
        public async Task<List<Revenue>> GetAsNoTrackingAsync(string caregories)
        {
            return await Context.Revenue
                .AsNoTracking()
                .Where(e => e.Categories == caregories)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalRevenueAsync(DateTime startDate, DateTime endDate)
        {
            return await Context.Revenue
               .AsNoTracking()
               .Where(e => e.Date >= startDate && e.Date <= endDate)
               .SumAsync(e => e.Value);
        }
    }
}
