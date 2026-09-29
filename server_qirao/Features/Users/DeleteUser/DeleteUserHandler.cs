using Microsoft.EntityFrameworkCore;
using server_qirao.Infraestructure.Persistence;

namespace server_qirao.Features.Users.DeleteUser;

public enum DeleteUserResult
{
    Deleted,
    NotFound,
    Forbidden,
    Error
}

public class DeleteUserHandler(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext;

    /// Elimina al usuario y, por cascada, su progreso y respuestas del quiz.
    /// Solo el dueño puede hacerlo: se valida con su KeyAccessUser.
    public async Task<DeleteUserResult> HandleAsync(string userId, string keyAccessUser)
    {
        try
        {
            var usuario = await _dbContext.Usuarios
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (usuario is null)
                return DeleteUserResult.NotFound;

            if (usuario.KeyAccessUser != keyAccessUser)
                return DeleteUserResult.Forbidden;

            _dbContext.Usuarios.Remove(usuario);
            await _dbContext.SaveChangesAsync();

            return DeleteUserResult.Deleted;
        }
        catch (Exception)
        {
            return DeleteUserResult.Error;
        }
    }
}
