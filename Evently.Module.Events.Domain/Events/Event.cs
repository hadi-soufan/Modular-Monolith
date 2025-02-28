﻿using Evently.Module.Events.Domain.Abstractions;

namespace Evently.Module.Events.Domain.Events;

public sealed class Event : Entity
{
    private Event() { }

    public Guid Id { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Location { get; private set; }

    public DateTime StartsAtUtc { get; private set; }

    public DateTime? EndsAtUtc { get; private set; }

    public EventStatus Status { get; private set; }

    public static Event Create(string title, string description, string Location, DateTime StartsAtUtc, DateTime? EndsAtUtc)
    {
        var @event = new Event
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Location = Location,
            StartsAtUtc = StartsAtUtc,
            EndsAtUtc = EndsAtUtc,
            Status = EventStatus.Draft
        };

        @event.Raise(new EventCreatedDomainEvent(@event.Id));

        return @event;
    }
}
