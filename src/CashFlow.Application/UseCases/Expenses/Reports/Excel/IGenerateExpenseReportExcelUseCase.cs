namespace CashFlow.Application.UseCases.Expenses.Reports.Excel;

public interface IGenerateExpenseReportExcelUseCase
{
    Task<byte[]> ExecuteAsync(DateOnly month);
}