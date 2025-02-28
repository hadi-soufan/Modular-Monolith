using Evently.Module.Events.Domain.Events;
using Evently.Module.Events.Infrastructure.Database;

namespace Evently.Module.Events.Infrastructure.Events;

internal sealed class EventRepository(EventsDbContext context) : IEventRepository
{
    public void Insert(Event @event)
    {
        context.Events.Add(@event);
    }
}
