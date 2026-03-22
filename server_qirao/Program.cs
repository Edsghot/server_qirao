using Microsoft.EntityFrameworkCore;
using server_qirao.Infraestructure.Persistence;
using server_qirao.Features.Sync.SyncUserData;
using server_qirao.Features.Quiz.GetLevels;
using server_qirao.Features.Quiz.GetUserResults;

var builder = WebApplication.CreateBuilder(args);

// Puerto de Railway (usa la variable de entorno PORT)
var port = Environment.GetEnvironmentVariable("PORT") ?? "5156";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// OpenAPI
builder.Services.AddOpenApi();

// DbContext con MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? Environment.GetEnvironmentVariable("CONNECTION_STRING");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString!, ServerVersion.AutoDetect(connectionString!)));

// CORS para Flutter
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFlutterApp", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Registrar servicios de features
builder.Services.AddScoped<SyncUserDataHandler>();
builder.Services.AddScoped<GetLevelsHandler>();
builder.Services.AddScoped<GetUserResultsHandler>();

var app = builder.Build();

// Auto-migrate: aplica migraciones pendientes al iniciar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowFlutterApp");

// Mapear endpoints
app.MapSyncEndpoints();
app.MapQuizEndpoints();

app.Run();
