using System.Net.Mime;
using CashFlow.Application.UseCases.Expenses.Reports.Excel;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet("excel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetExcel([FromHeader] DateOnly request,
            [FromServices] IGenerateExpenseReportExcelUseCase useCase)
        {
            var data = await useCase.ExecuteAsync(request);

            if (data.Length > 0)
                return File(data, MediaTypeNames.Application.Octet, "report.xlsx");

            return NoContent();
        }
    }
}
