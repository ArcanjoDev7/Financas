using Financas.Domain.Models;

namespace Financas.Persistence.Repositories.Interfaces
{
    public interface IRevenueRepository : IRepositoryBase<Revenue>
    {
        Task<bool> CategoriesExistAsync(string categories);
        Task<List<Revenue>> GetAsNoTrackingAsync(string categories);
        Task<decimal> GetTotalRevenueAsync(DateTime startDate, DateTime endDate);
    }
}
