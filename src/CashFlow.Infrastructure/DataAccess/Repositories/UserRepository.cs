using System;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly CashFlowDbContext _context;
    public UserRepository(CashFlowDbContext context) => _context = context;

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> ExistActiveUserWithEmailAsync(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email.Equals(email));
    }
}
