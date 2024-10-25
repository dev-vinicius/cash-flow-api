using System;
using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesRepository
{
    Task<List<Expense>> GetAllAsync();
    Task AddAsync(Expense expense);
}
