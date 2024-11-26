using System;
using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesRepository
{
    Task<List<Expense>> GetAllAsync();
    Task<Expense?> GetByIdAsync(long id);
    Task AddAsync(Expense expense);
}
