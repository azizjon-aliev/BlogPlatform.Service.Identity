using Identity.Domain.Entities;
using MediatR;

namespace Identity.Application.Account.Commands.Refresh;

public class RefreshCommand : IRequest<TokenInfo>
{
    public string RefreshToken { get; set; } = string.Empty;
}