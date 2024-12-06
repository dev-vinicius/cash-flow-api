namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf;

public interface IGenerateExpenseReportPdfUseCase
{
    Task<byte[]> ExecuteAsync(DateOnly month);
}