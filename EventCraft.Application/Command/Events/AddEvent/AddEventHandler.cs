using EventCraft.Application.Common;
using EventCraft.Application.Interfaces;
using EventCraft.Application.Services;
using EventCraft.Domain.Events;
using MediatR;
using System.Diagnostics.Tracing;

namespace EventCraft.Application.Command.Events.AddEvent;

public record AddEventCommand(
    string EventName,
    string Description,
    string EventCategory,
    int MaxNumberOfPeople,
    bool IsEventOffline,
    bool IsEventFree,
    decimal EventPrice,
    decimal Lan,
    decimal Lng,
    string EventOnlineUrl) : IRequest<Response>;

public class AddEventHandler : IRequestHandler<AddEventCommand, Response>
{
    private readonly IEventRepository _eventRepository;
    private readonly IUserService _userService;

    public AddEventHandler(
        IEventRepository eventRepository,
        IUserService userService)
    {
        _eventRepository = eventRepository;
        _userService = userService;
    }

    public async Task<Response> Handle(AddEventCommand request, CancellationToken cancellationToken)
    {
        var eventAuthorId = _userService.GetCurrentUserId();

        if (eventAuthorId is null)
        {
            return Response.Error("Refresh the page");
        }

        var newEvent = new Event
        {
            AuthorId = eventAuthorId,
            IsFree = request.IsEventFree,
            Category = EventCategory.Entertainment,
            Description = request.Description,
            MaxNumberOfPeople = request.MaxNumberOfPeople,
            IsOffline = request.IsEventOffline,
            Price = request.EventPrice,
            OnlineUrl = request.EventOnlineUrl,
            Location = new GeoLocation(request.Lng, request.Lan),
            Name = request.EventName,
        };

        await _eventRepository.AddAsync(newEvent);

        await _eventRepository.SaveChangesAsync();
        return Response.Ok().Add("newEvent", newEvent);
    }
}