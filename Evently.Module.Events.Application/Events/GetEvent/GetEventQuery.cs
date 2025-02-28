using MediatR;

namespace Evently.Module.Events.Application.Events.GetEvent;

public sealed record GetEventQuery(Guid EventId) : IRequest<EventResponse?>;
