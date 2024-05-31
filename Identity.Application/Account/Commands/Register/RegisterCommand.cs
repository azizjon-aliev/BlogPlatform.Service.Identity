using Identity.Domain.Entities;
using MediatR;

namespace Identity.Application.Account.Commands.Register;

public class RegisterCommand : IRequest<TokenInfo>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
}