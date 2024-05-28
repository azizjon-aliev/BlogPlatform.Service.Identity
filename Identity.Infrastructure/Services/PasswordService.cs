using Identity.Application.Common.Contracts.Services;

namespace Identity.Infrastructure.Services;

public class PasswordService : IPasswordService
{
    public bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }

    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}