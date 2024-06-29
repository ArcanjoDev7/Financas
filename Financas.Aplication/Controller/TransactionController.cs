using Financas.Domain.Models;
using Financas.Infra.Persistence.Repositories;
using Financas.Infra.Persistence.Repositories.Interfaces;
using Financas.Persistence.Repositories;
using Financas.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Aplication.Controller
{
    [ApiController]
    [Route("transaction")]
    public class TransactionController(ITransactionRepository transactionRepository, IUserRepository userRepository) : ControllerBase
    {
        protected readonly ITransactionRepository TransactionRepository = transactionRepository;
        protected readonly IUserRepository UserRepository = userRepository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await UserRepository.GetAsNoTrackingAsync(User.Identity.Name);
            if (user is null)
            {
                return Unauthorized();
            }
            var todos = await TransactionRepository.GetAllAsync(user.Id);
            return Ok(todos);
        }
    }
}

