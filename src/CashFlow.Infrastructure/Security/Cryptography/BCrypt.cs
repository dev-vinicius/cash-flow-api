using System;
using CashFlow.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infrastructure.Security.Cryptography;

public class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        return BC.HashPassword(password);
    }
}
