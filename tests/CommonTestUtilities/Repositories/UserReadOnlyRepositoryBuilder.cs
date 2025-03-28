using System;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;
using Moq;

namespace CommonTestUtilities.Repositories;

public class UserReadOnlyRepositoryBuilder
{
    private readonly Mock<IUserReadOnlyRepository> _repository;

    public UserReadOnlyRepositoryBuilder()
    {
        _repository = new Mock<IUserReadOnlyRepository>();
    }

    public void ExistActiveUserWithEmailAsync(string email)
    {
        _repository.Setup(x => x.ExistActiveUserWithEmailAsync(email)).ReturnsAsync(true);
    }

    public UserReadOnlyRepositoryBuilder GetUserByEmailAsync(User user)
    {
        _repository.Setup(x => x.GetUserByEmailAsync(user.Email)).ReturnsAsync(user);
        return this;
    }

    public IUserReadOnlyRepository Build() => _repository.Object;
}
