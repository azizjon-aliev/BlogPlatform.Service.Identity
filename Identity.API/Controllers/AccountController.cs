using Identity.Application.Account.Commands.Login;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
[Produces("application/json")]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TokenInfo>> Login([FromBody] LoginCommand request)
    {
        var response = await mediator.Send(request);
        return Ok(response);
    }
}