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
        private readonly IMemoryCache _cache;

        public FeedItemController(
            ISender mediator, 
            IMemoryCache cache)
        {
            _mediator = mediator;
            _cache = cache;
        }


        [HttpGet("GetFeedItems")]
        public async Task<IActionResult> GetFeedItems()
        {
            

            return Ok();
        }


    }
}
