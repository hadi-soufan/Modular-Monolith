﻿namespace Evently.Module.Events.Domain.Events;
public interface IEventRepository
{
    void Insert(Event @event);
}
