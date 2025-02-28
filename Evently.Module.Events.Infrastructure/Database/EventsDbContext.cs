using Evently.Module.Events.Application.Abstractions.Data;
using Evently.Module.Events.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace Evently.Module.Events.Infrastructure.Database;

public sealed class EventsDbContext(DbContextOptions<EventsDbContext> options) : DbContext(options), IUnitOfWork
{
    internal DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Events);
    }
}
