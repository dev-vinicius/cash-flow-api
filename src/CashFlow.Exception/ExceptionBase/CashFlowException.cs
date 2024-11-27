using System;

namespace CashFlow.Exception.ExceptionBase;

public abstract class CashFlowException : SystemException
{
    public abstract int StatusCode { get; }
    protected CashFlowException(string message) : base(message)
    {
    }

    public abstract List<string> GetErrors();
}
