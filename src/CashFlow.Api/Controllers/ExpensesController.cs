using CashFlow.Application.UseCases.Expenses.Get;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseExpensesJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllExpenses([FromServices] IGetExpensesUseCase useCase)
        {
            var result = await useCase.ExecuteAsync();
            
            if (result.Expenses.Count != 0)
                return Ok(result);
            
            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredExpenseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RequestRegisterExpenseJson request, 
            [FromServices] IRegisterExpenseUseCase useCase)
        {
            var result = await useCase.ExecuteAsync(request);
            return Created(string.Empty, result);
        }
    }
}
