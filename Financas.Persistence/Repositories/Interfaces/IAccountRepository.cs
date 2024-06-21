using Financas.Domain.Models;
using Financas.Persistence.Repositories.Interfaces;

namespace Financas.Infra.Persistence.Repositories.Interfaces
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {

        Task<Account?> GetByIdAsync(Guid id);
        Task<Account?> GetByNameAsync(string name);
        Task CreateAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(Guid id);
    }
}
