using EventCraft.Application.Common;
using EventCraft.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EventCraft.Application.Query.GetAllEvents;

public record GetAllEventsQuery() : IRequest<Response>;

internal class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, Response>
{
    private readonly IEventRepository _eventRepository;

    public GetAllEventsQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Response> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
    {
        var list = await _eventRepository.GetAll().ToListAsync();

        return Response.Ok().Add("events", list);
    }
}