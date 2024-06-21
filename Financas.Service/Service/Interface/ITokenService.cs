using Financas.Domain.Models;

namespace Financas.Service.Service.Interface
{
    public interface ITokenService
    {
        string GetToken(User user);
    }
}
