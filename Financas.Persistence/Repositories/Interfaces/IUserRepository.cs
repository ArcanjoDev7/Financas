using Financas.Domain.Models;

namespace Financas.Persistence.Repositories.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<bool> EmailExistAsync(string email);

        Task<User?> GetAsync(string email);

        Task<User?> GetAsNoTrackingAsync(string email);
    }
}
