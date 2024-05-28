using Identity.Application.Common.Contracts.Repositories;
using Identity.Application.Common.Contracts.Services;
using Identity.Domain.Entities;
using MediatR;

namespace Identity.Application.Account.Commands.Login;

public class LoginCommandHandler(
    IUserRepository repository,
    ITokenService tokenService,
    IPasswordService passwordService)
    : IRequestHandler<LoginCommand, TokenInfo>
{
    public async Task<TokenInfo> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetByUsernameAsync(request.Username, cancellationToken);
        if (user == null)
        {
            throw new Exception("Неверное имя пользователя или пароль");
        }

        if (!passwordService.VerifyPassword(request.Password, user.Password))
        {
            throw new Exception("Неверное имя пользователя или пароль");
        }

        return tokenService.GenerateToken(user);
    }
}