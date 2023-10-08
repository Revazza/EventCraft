using EventCraft.Application.Common;
using MediatR;

namespace EventCraft.Application.Command.Events.AddEvent;

public record AddEventCommand(
    string EventName,
    string EventCategory) : IRequest<Response>;

public class AddEventHandler
{

}