using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace EventCraft.Api.Controllers
{
    [Route("public/api/v1/FeedItem")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "User")]
    [ApiController]
    public class FeedItemController : ControllerBase
    {
        private readonly ISender _mediator;

        public FeedItemController(
            ISender mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetFeedItems")]
        public async Task<IActionResult> GetFeedItems()
        {
            

            return Ok();
        }


    }
}
