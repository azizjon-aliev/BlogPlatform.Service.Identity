using Identity.Domain.Entities;

namespace Identity.Application.Common.Contracts.Services;

public interface ITokenService
{
    public TokenInfo GenerateToken(User user);
}