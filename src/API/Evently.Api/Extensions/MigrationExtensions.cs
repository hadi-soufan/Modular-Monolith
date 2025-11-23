using Evently.Modules.Events.Infrastructure.Database;
using Evently.Modules.Ticketing.Infrastructure.Database;
using Evently.Modules.Users.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;

namespace Evently.Api.Extensions;

internal static class MigrationExtensions
{
    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigration<EventsDbContext>(scope);
        ApplyMigration<UsersDbContext>(scope);
        ApplyMigration<TicketingDbContext>(scope);
    }

    private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        // Retry policy to handle database connection issues during startup
        ResiliencePipeline pipeline = new ResiliencePipelineBuilder()
            .AddRetry(new RetryStrategyOptions
            {
                MaxRetryAttempts = 5,
                Delay = TimeSpan.FromSeconds(2),
                BackoffType = DelayBackoffType.Exponential,
                UseJitter = true,
                OnRetry = args =>
                {
                    Console.WriteLine($"Migration attempt {args.AttemptNumber + 1} failed for {typeof(TDbContext).Name}. Retrying in {args.RetryDelay.TotalSeconds} seconds...");
                    return ValueTask.CompletedTask;
                }
            })
            .Build();

        pipeline.Execute(() => context.Database.Migrate());
    }
}
