﻿using Evently.Module.Events.Domain.Abstractions;

namespace Evently.Module.Events.Domain.Events;

public sealed class EventCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; init; } = eventId;
}
