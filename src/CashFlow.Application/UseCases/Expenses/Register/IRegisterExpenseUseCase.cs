using CashFlow.Communication.Responses;
using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.Expenses.Register;

public interface IRegisterExpenseUseCase
{
    Task<ResponseRegisteredExpenseJson> ExecuteAsync(RequestExpenseJson request);
}
