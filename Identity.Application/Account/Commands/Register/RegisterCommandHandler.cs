using Identity.Application.Common.Contracts.Repositories;
using Identity.Application.Common.Contracts.Services;
using Identity.Domain.Entities;
using MediatR;

namespace Identity.Application.Account.Commands.Register;

public class RegisterCommandHandler(
    IUserRepository repository,
    ITokenService tokenService,
    IPasswordService passwordService)
    : IRequestHandler<RegisterCommand, TokenInfo>
{
    public async Task<TokenInfo> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            Password = passwordService.HashPassword(request.Password)
        };

        var newUser = await repository.AddAsync(user, cancellationToken);

        return await tokenService.GenerateToken(newUser, cancellationToken);
    }
}