using server_qirao.Features.Sync.Contracts;

namespace server_qirao.Features.Sync.SyncUserData;

public static class SyncEndpoints
{
    public static void MapSyncEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api");

        group.MapPost("/sync-user-data", async (SyncUserDataRequest request, SyncUserDataHandler handler) =>
        {
            var result = await handler.HandleAsync(request);

            if (result.IsSuccess)
            {
                return Results.Ok(result.Value);
            }

            return Results.BadRequest(new SyncUserDataResponse(
                Success: false,
                Message: result.Error ?? "Error desconocido",
                SyncedAt: DateTime.UtcNow
            ));
        })
        .WithName("SyncUserData")
        .WithOpenApi();
    }
}
