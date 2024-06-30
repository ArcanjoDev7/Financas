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
            public async Task<IActionResult> Create([FromBody] CreateRevenueRequest model)
            {
                if(await RevenueRepository.CategoriesExistAsync(model.Categories))
                {
                    return BadRequest(new
                    {
                        Message = "A categoria ja esta em uso."
                    });
                }
                var categories = new Revenue
                {
                    Categories = model.Categories,
                    Description = model.Description,
                    CreatedAt = DateTime.UtcNow
                };
                await RevenueRepository.CreateAsync(categories);
                await RevenueRepository.SaveAsync();
                return Created("", categories);
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
