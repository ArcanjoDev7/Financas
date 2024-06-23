using Financas.Domain.Models;

namespace Financas.Persistence.Repositories.Interfaces
{
    public interface IRevenueRepository : IRepositoryBase<Revenue>
    {
        Task<IEnumerable<Revenue>> GetByCategoria(string categoria);
        Task<IEnumerable<Revenue>> GetByDateRange(DateTime startDate, DateTime endDate);
        Task<decimal> GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate);
    }
}
