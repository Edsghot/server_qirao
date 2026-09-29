using Microsoft.AspNetCore.Mvc;

namespace server_qirao.Features.Users.DeleteUser;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api");

        // Eliminación de cuenta (App Store 5.1.1(v)).
        // 204 también cuando el usuario no existe (nunca sincronizó o ya fue
        // eliminado), para que la app pueda completar el borrado local.
        group.MapDelete("/users/{userId}", async (
            string userId,
            [FromHeader(Name = "X-Key-Access")] string? keyAccessUser,
            DeleteUserHandler handler) =>
        {
            if (string.IsNullOrWhiteSpace(keyAccessUser))
                return Results.Unauthorized();

            var result = await handler.HandleAsync(userId, keyAccessUser);

            return result switch
            {
                DeleteUserResult.Deleted or DeleteUserResult.NotFound => Results.NoContent(),
                DeleteUserResult.Forbidden => Results.StatusCode(StatusCodes.Status403Forbidden),
                _ => Results.Problem("Error al eliminar el usuario")
            };
        })
        .WithName("DeleteUser")
        .WithOpenApi();
    }
}
