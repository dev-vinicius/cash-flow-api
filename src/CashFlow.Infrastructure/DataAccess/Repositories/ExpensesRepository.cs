using System;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository : IExpensesWriteOnlyRepository, IExpensesReadOnlyRepository
{
    private readonly CashFlowDbContext _context;
    public ExpensesRepository(CashFlowDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Expense expense)
    {
        await _context.Expenses.AddAsync(expense);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var result = await _context.Expenses.FirstOrDefaultAsync(x => x.Id == id);
        if (result is null)
            return false;

        _context.Expenses.Remove(result);
        return true;
    }

    public async Task<List<Expense>> GetAllAsync()
    {
        return await _context.Expenses.AsNoTracking().ToListAsync();
    }

    public async Task<Expense?> GetByIdAsync(long id)
    {
        return await _context.Expenses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
}
