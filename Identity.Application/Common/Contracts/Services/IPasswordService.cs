namespace Identity.Application.Common.Contracts.Services;

public interface IPasswordService
{
    public bool VerifyPassword(string password, string hash);

    public string HashPassword(string password);
}