namespace server_qirao.Features.Quiz.GetLevels;

public static class QuizEndpoints
{
    public static void MapQuizEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api");

        group.MapGet("/quiz/levels", async (GetLevelsHandler handler) =>
        {
            var result = await handler.HandleAsync();

            if (result.IsSuccess)
            {
                return Results.Ok(result.Value);
            }

            return Results.BadRequest(new { error = result.Error });
        })
        .WithName("GetQuizLevels")
        .WithOpenApi();
    }
}
