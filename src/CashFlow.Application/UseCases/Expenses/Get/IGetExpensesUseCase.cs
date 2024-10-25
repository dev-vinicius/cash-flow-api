using System;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Get;

public interface IGetExpensesUseCase
{
    Task<ResponseExpensesJson> ExecuteAsync();
}
