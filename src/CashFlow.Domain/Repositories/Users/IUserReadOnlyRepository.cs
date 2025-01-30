using System;

namespace CashFlow.Domain.Repositories.Users;

public interface IUserReadOnlyRepository
{
    Task<bool> ExistActiveUserWithEmailAsync(string email);
}
