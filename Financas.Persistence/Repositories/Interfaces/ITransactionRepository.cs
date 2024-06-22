using Financas.Domain.Models;
using Financas.Persistence.Repositories.Interfaces;

namespace Financas.Infra.Persistence.Repositories.Interfaces
{
    public interface ITransactionRepository : IRepositoryBase<Transaction>
    {
        Task<Transaction?> GetByIdAsync(Guid id);
    }
}
