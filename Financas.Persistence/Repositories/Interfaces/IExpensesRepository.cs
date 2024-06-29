using Financas.Domain.Models;

namespace Financas.Persistence.Repositories.Interfaces
{
    public interface IExpensesRepository : IRepositoryBase<Expenses>
    {
        Task<List<Expenses>> GetAsNoTrackingAsync(string categories);
        Task<decimal> GetTotalExpensesAsync(DateTime startDate, DateTime endDate);
    }
}
