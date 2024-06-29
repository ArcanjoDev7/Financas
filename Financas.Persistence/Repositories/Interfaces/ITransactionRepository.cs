using Financas.Domain.Models;
using Financas.Persistence.Repositories.Interfaces;

namespace Financas.Infra.Persistence.Repositories.Interfaces
{
    public interface ITransactionRepository : IRepositoryBase<Transaction>
    {
        Task<List<Transaction>> GetAllAsync(Guid userId);
        Task<Transaction?> GetByIdAsync(Guid id);
        Task<decimal> GetTotalAmountTransactionAsync(DateTime startDate, DateTime endDate);
    }
}
