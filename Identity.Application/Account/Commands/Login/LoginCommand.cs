using Identity.Domain.Entities;
using MediatR;

namespace Identity.Application.Account.Commands.Login;

public class LoginCommand : IRequest<TokenInfo>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}