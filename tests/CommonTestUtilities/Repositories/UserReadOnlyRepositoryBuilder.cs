using System;
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

    public IUserReadOnlyRepository Build() => _repository.Object;
}
