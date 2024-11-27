using System;
using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.Get;

public class GetExpensesUseCase : IGetExpensesUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetExpensesUseCase(
        IExpensesReadOnlyRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseExpensesJson> ExecuteAsync()
    {
        var result = await _repository.GetAllAsync();
        return new ResponseExpensesJson{
            Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result)
        };
    }
}
