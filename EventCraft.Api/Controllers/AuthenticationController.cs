using EventCraft.Application.Command.AddUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventCraft.Api.Controllers;

[Route("public/api/v1/Authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{

    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("AddUser")]
    public async Task<IActionResult> AddUser(AddUserRequest r)
    {
        var command = new AddUserCommand(r.UserName, r.Email, r.Password);
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(AddUserRequest r)
    {
        var command = new AddUserCommand(r.UserName, r.Email, r.Password);
        var response = await _mediator.Send(command);
        return Ok(response);
    }

}
