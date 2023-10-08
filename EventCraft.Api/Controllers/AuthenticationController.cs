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

    [HttpPost("RegisterUser")]
    public async Task<IActionResult> RegisterUser()
    {
        //var command = ;
        //var response = await _mediator.Send();
        return Ok();
    }


}
