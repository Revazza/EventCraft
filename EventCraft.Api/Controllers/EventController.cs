using EventCraft.Application.Command.Events.AddEvent;
using EventCraft.Application.Query.GetAllEvents;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventCraft.Api.Controllers
{
    [Route("public/api/v1/Event")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "User")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ISender _sender;

        public EventController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("AddEvent")]
        public async Task<IActionResult> AddEvent(AddEventCommand request)
        {
            var command = request;
            var response = await _sender.Send(command);
            return Ok(response);
        }


        [HttpGet("GetAllEvents")]
        public async Task<IActionResult> GetAllEvents()
        {
            var query = new GetAllEventsQuery();
            var response = await _sender.Send(query);
            return Ok(response);
        }


    }
}
