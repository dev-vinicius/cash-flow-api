using System;

namespace CashFlow.Domain.Repositories;

public interface IUnityOfWork
{
    Task Commit();
}
