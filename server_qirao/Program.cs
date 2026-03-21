using Microsoft.EntityFrameworkCore;
using server_qirao.Infraestructure.Persistence;
using server_qirao.Features.Sync.SyncUserData;
using server_qirao.Features.Quiz.GetLevels;

var builder = WebApplication.CreateBuilder(args);

// OpenAPI
builder.Services.AddOpenApi();

// DbContext con MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// CORS para desarrollo local (Flutter)
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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowFlutterApp");

// Mapear endpoints
app.MapSyncEndpoints();
app.MapQuizEndpoints();

app.Run();
