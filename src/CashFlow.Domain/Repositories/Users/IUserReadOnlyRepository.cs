using System;
using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Users;

public interface IUserReadOnlyRepository
{
    Task<bool> ExistActiveUserWithEmailAsync(string email);
    Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
}
