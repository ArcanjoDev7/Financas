using Financas.Domain.Models;
using Financas.Domain.Requests;
using Financas.Infra.Persistence.Repositories.Interfaces;
using Financas.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Aplication.Controller
{
    [ApiController]
    [Route("transaction")]
    public class TransactionController(ITransactionRepository transactionRepository, IUserRepository userRepository) : ControllerBase
    {
        protected readonly ITransactionRepository TransactionRepository = transactionRepository;
        protected readonly IUserRepository UserRepository = userRepository;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionRequest model)
        {
            if (await TransactionRepository.TransactionExistAsync(model.Description))
            {
                return BadRequest(new
                {
                    Message = "O Transaction ja esta em uso."
                });
            }
            var userId = User.FindFirst("sub")?.Value;

            if (userId is null)
            {
                return Unauthorized();
            }
            var transaction = new Transaction
            {
               
                Description = model.Description,
                Amount = model.Balance,
                UserId = Guid.Parse(userId),
                CreatedAt = DateTime.UtcNow
            };
            await TransactionRepository.CreateAsync(transaction);
            await TransactionRepository.SaveAsync();
            return Created("", transaction);
        }
    }
}

