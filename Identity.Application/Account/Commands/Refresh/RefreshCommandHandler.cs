using System.Net;
using Identity.Application.Account.Commands.Login;
using Identity.Application.Common.Contracts.Repositories;
using Identity.Application.Common.Contracts.Services;
using Identity.Application.Common.Exceptions;
using Identity.Domain.Entities;
using MediatR;

namespace Identity.Application.Account.Commands.Refresh;

public class RefreshCommandHandler(IUserRepository repository, ITokenService service)
    : IRequestHandler<RefreshCommand, TokenInfo>
{
    public async Task<TokenInfo> Handle(RefreshCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetByRefreshToken(request.RefreshToken, cancellationToken);
        if (user == null)
        {
            throw new CustomException(message: "Токен обновления не найден", code: HttpStatusCode.Unauthorized);
        }

        if (user.RefreshTokenExpiryTime < DateTime.UtcNow)
        {
            throw new CustomException(message: "Токен обновления просрочен", code: HttpStatusCode.Unauthorized);
        }

        var tokenInfo = await service.GenerateToken(user, cancellationToken);

        return tokenInfo;
    }
}