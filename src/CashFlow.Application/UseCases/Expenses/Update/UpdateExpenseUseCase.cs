using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Update;

public class UpdateExpenseUseCase : IUpdateExpenseUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnityOfWork _unityOfWork;
    private readonly IExpensesUpdateOnlyRepository _repository;
    public UpdateExpenseUseCase(IMapper mapper, 
        IUnityOfWork unityOfWork, 
        IExpensesUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unityOfWork = unityOfWork;
        _repository = repository;
    }
    public async Task ExecuteAsync(long id, RequestExpenseJson request)
    {
        Validate(request);

        var expense = await _repository.GetByIdAsync(id);

        if (expense is null)
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);

        _mapper.Map(request, expense);

        _repository.Update(expense);

        await _unityOfWork.Commit();
    }

    private void Validate(RequestExpenseJson request)
    {
        var validator = new ExpenseValidator();
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var errors = result.Errors
                .Select(error => error.ErrorMessage)
                .ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
}
