﻿using EventCraft.Application.Query.FeedItems.GetAllFeedItems;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [AllowAnonymous]
        [HttpGet("GetFeedItems")]
        public async Task<IActionResult> GetFeedItems()
        {
            var query = new GetAllFeedItemsQuery();
            var response = await _mediator.Send(query);

            return Ok(response);
        }


    }
}
