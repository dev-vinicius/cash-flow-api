using System;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository : IExpensesRepository
{
    private readonly CashFlowDbContext _context;
    public ExpensesRepository(CashFlowDbContext context)
    {
        _context = context;
    }

    public async Task Add(Expense expense)
    {
        await _context.Expenses.AddAsync(expense);
    }
}
