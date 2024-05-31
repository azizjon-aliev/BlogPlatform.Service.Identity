using System.Security.Claims;
using Identity.Domain.Entities;

namespace Identity.Application.Common.Contracts.Services;

public interface ITokenService
{
    public Task<TokenInfo> GenerateToken(User user, CancellationToken cancellationToken);

    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}