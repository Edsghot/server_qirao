using Microsoft.EntityFrameworkCore;
using server_qirao.Domain.Common;
using server_qirao.Domain.Entities;
using server_qirao.Features.Sync.Contracts;
using server_qirao.Infraestructure.Persistence;

namespace server_qirao.Features.Sync.SyncUserData;

public class SyncUserDataHandler(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<Result<SyncUserDataResponse>> HandleAsync(SyncUserDataRequest request)
    {
        try
        {
            var now = DateTime.UtcNow;

            // 1. Buscar o crear usuario
            var usuario = await _dbContext.Usuarios
                .FirstOrDefaultAsync(u => u.Id == request.User.Id);

            if (usuario is null)
            {
                usuario = new Usuario
                {
                    Id = request.User.Id,
                    Name = request.User.Name,
                    LastName = request.User.LastName,
                    Age = request.User.Age,
                    KeyAccessUser = request.User.KeyAccessUser,
                    Pais = request.User.Pais,
                    Language = request.User.Language,
                    GamificationEnabled = request.User.GamificationEnabled,
                    LastSyncDate = now,
                    CreatedAt = now,
                    UpdatedAt = now
                };
                _dbContext.Usuarios.Add(usuario);
            }
            else
            {
                usuario.Name = request.User.Name;
                usuario.LastName = request.User.LastName;
                usuario.Age = request.User.Age;
                usuario.Pais = request.User.Pais;
                usuario.Language = request.User.Language;
                usuario.GamificationEnabled = request.User.GamificationEnabled;
                usuario.LastSyncDate = now;
                usuario.UpdatedAt = now;
            }

            // 2. Sincronizar progreso de quiz
            foreach (var progress in request.QuizProgress)
            {
                // Verificar que el QuizLevel existe
                var levelExists = await _dbContext.QuizLevels
                    .AnyAsync(l => l.Id == progress.Id);

                if (!levelExists) continue;

                var existingProgress = await _dbContext.UserQuizProgress
                    .FirstOrDefaultAsync(p => p.UserId == request.User.Id && p.QuizLevelId == progress.Id);

                if (existingProgress is null)
                {
                    var newProgress = new UserQuizProgress
                    {
                        UserId = request.User.Id,
                        QuizLevelId = progress.Id,
                        IsLocked = progress.IsLocked,
                        IsCompleted = progress.IsCompleted,
                        Stars = progress.Stars,
                        Points = progress.Points,
                        UpdatedAt = now
                    };
                    _dbContext.UserQuizProgress.Add(newProgress);
                }
                else
                {
                    existingProgress.IsLocked = progress.IsLocked;
                    existingProgress.IsCompleted = progress.IsCompleted;
                    existingProgress.Stars = progress.Stars;
                    existingProgress.Points = progress.Points;
                    existingProgress.UpdatedAt = now;
                }
            }

            await _dbContext.SaveChangesAsync();

            var response = new SyncUserDataResponse(
                Success: true,
                Message: "Datos sincronizados correctamente",
                SyncedAt: now
            );

            return Result<SyncUserDataResponse>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<SyncUserDataResponse>.Failure($"Error al sincronizar: {ex.Message}");
        }
    }
}
