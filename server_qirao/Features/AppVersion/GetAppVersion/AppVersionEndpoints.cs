namespace server_qirao.Features.AppVersion.GetAppVersion;

/// Versiones por plataforma. En Railway se configuran con variables de entorno:
///   AppVersion__Ios__MinVersion=1.1.0
///   AppVersion__Ios__LatestVersion=1.2.0
///   AppVersion__Ios__StoreUrl=https://apps.apple.com/app/id...
///   AppVersion__Android__MinVersion=...
public sealed class PlatformVersionOptions
{
    /// Por debajo de esta versión la app se bloquea hasta actualizar.
    public string MinVersion { get; set; } = "0.0.0";

    /// Por debajo de esta versión se sugiere actualizar (se puede omitir).
    public string LatestVersion { get; set; } = "0.0.0";

    public string StoreUrl { get; set; } = "";
}

public sealed record AppVersionResponse(
    string MinVersion,
    string LatestVersion,
    string StoreUrl
    );

public static class AppVersionEndpoints
{
    public static void MapAppVersionEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api");

        group.MapGet("/app-version", (string platform, IConfiguration configuration) =>
        {
            var section = platform.ToLowerInvariant() switch
            {
                "ios" => "AppVersion:Ios",
                "android" => "AppVersion:Android",
                _ => null
            };

            if (section is null)
                return Results.BadRequest(new { error = "platform debe ser 'ios' o 'android'" });

            var options = configuration.GetSection(section).Get<PlatformVersionOptions>()
                          ?? new PlatformVersionOptions();

            return Results.Ok(new AppVersionResponse(
                options.MinVersion,
                options.LatestVersion,
                options.StoreUrl
            ));
        })
        .WithName("GetAppVersion")
        .WithOpenApi();
    }
}
