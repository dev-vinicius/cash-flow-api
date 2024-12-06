using System.Net.Mime;
using CashFlow.Application.UseCases.Expenses.Reports.Excel;
using CashFlow.Application.UseCases.Expenses.Reports.Pdf;
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
        public async Task<IActionResult> GetExcel([FromHeader] DateOnly month,
            [FromServices] IGenerateExpenseReportExcelUseCase useCase)
        {
            var data = await useCase.ExecuteAsync(month);

            if (data.Length > 0)
                return File(data, MediaTypeNames.Application.Octet, "report.xlsx");

            return NoContent();
        }
        
        [HttpGet("pdf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPdf([FromHeader] DateOnly month,
            [FromServices] IGenerateExpenseReportPdfUseCase useCase)
        {
            var data = await useCase.ExecuteAsync(month);

            if (data.Length > 0)
                return File(data, MediaTypeNames.Application.Pdf, "report.pdf");

            return NoContent();
        }
    }
}
