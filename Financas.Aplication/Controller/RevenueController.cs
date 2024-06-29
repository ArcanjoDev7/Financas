using Financas.Domain.Models;
using Financas.Domain.Requests;
using Financas.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Aplication.Controller
{
    [ApiController]
    [Route("revenue")]
    public class RevenueController
    {
        public class ExpensesController(IRevenueRepository revenueRepository, IUserRepository userRepository) : ControllerBase
        {
            protected readonly IRevenueRepository RevenueRepository = revenueRepository;
            protected readonly IUserRepository UserRepository = userRepository;

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] CreateExpensesRequest model)
            {
                var expenses = await RevenueRepository.GetAsNoTrackingAsync(User.Identity.Name);
                if (expenses is null)
                {
                    return Unauthorized();
                }
                var categories = new Revenue
                {
                    Categories = model.Categories,
                    Description = model.Description
                };
                await RevenueRepository.CreateAsync(categories);
                await RevenueRepository.SaveAsync();
                return Ok();
            }
            [HttpGet]

            public async Task<ActionResult> Get()
            {
                var revenue = await RevenueRepository.GetAsNoTrackingAsync(User.Identity.Name);
                if (revenue is null)
                {
                    return Unauthorized();
                }
                var total = await RevenueRepository.GetTotalRevenueAsync(DateTime.MinValue, DateTime.MaxValue);
                return Ok(new { TotalExpenses = total, ExpensesList = revenue });
            }
        }
    }
}
