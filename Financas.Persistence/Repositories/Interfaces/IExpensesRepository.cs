using Financas.Domain.Models;

namespace Financas.Persistence.Repositories.Interfaces
{
    public interface IExpensesRepository : IRepositoryBase<Expenses>
    {
        Task<IEnumerable<Expenses>> GetByCategoria(string categoria);
        Task<IEnumerable<Expenses>> GetByDateRange(DateTime startDate, DateTime endDate);
        Task<decimal> GetTotalExpensesByDateRange(DateTime startDate, DateTime endDate);
    }
}
