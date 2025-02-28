using Microsoft.AspNetCore.Routing;

namespace Evently.Module.Events.Presentation.Events;
public static class EventEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        GetEvent.MapEndpoint(app);
        CreateEvent.MapEndpoint(app);
    }
}
