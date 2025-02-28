using Evently.Module.Events.Application.Abstractions.Data;
using Evently.Module.Events.Domain.Events;
using MediatR;

namespace Evently.Module.Events.Application.Events.CreateEvent;

internal sealed class CreateEventCommandHandler(IEventRepository eventRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateEventCommand, Guid>
{
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = Event.Create(request.Title, request.Description, request.Location, request.StartsAtUtc, request.EndsAtUtc);

        eventRepository.Insert(@event);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return @event.Id;
    }

}
