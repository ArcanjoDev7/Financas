using Financas.Domain.Models;
using Financas.Domain.Requests;
using Financas.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Aplication.Controller
{
    [ApiController]
    [Route("expenses")]
    public class ExpensesController(IExpensesRepository expensesRepository, IUserRepository userRepository) : ControllerBase
    {
        protected readonly IExpensesRepository ExpensesRepository = expensesRepository;
        protected readonly IUserRepository UserRepository = userRepository;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExpensesRequest model)
        {
            var expenses = await ExpensesRepository.GetAsNoTrackingAsync(User.Identity.Name);
            if (expenses is null)
            {
                return Unauthorized();
            }
            var categories = new Expenses
            {
                Categories = model.Categories,
                Description = model.Description
            };
            await ExpensesRepository.CreateAsync(categories);
            await ExpensesRepository.SaveAsync();
            return Ok();
        }
        [HttpGet]

        public async Task<ActionResult> Get() 
        {
            var expenses = await ExpensesRepository.GetAsNoTrackingAsync(User.Identity.Name);
            if(expenses is null)
            {
                return Unauthorized();
            }
            var total = await ExpensesRepository.GetTotalExpensesAsync(DateTime.MinValue, DateTime.MaxValue);
            return Ok(new { TotalExpenses = total, ExpensesList = expenses });
        }
    }
}


