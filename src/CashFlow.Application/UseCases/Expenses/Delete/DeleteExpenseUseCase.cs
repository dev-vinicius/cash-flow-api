using System;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Delete;

public class DeleteExpenseUseCase : IDeleteExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _repository;
    private readonly IUnityOfWork _unityOfWork;
    public DeleteExpenseUseCase(IExpensesWriteOnlyRepository repository, IUnityOfWork unityOfWork)
    {
        _repository = repository;
        _unityOfWork = unityOfWork;
    }
    public async Task ExecuteAsync(long id)
    {
        var result = await _repository.DeleteAsync(id);

        if (result == false)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        await _unityOfWork.Commit();
    }
}
