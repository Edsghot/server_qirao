using Microsoft.EntityFrameworkCore;
using server_qirao.Domain.Common;
using server_qirao.Features.Quiz.Contracts;
using server_qirao.Infraestructure.Persistence;

namespace server_qirao.Features.Quiz.GetLevels;

public class GetLevelsHandler(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<Result<List<GetLevelsResponse>>> HandleAsync()
    {
        try
        {
            var levels = await _dbContext.QuizLevels
                .Include(l => l.Questions)
                .OrderBy(l => l.Number)
                .ToListAsync();

            var response = levels.Select(level => new GetLevelsResponse(
                Id: level.Id,
                Number: level.Number,
                Name: level.Name,
                Mapa: level.Mapa,
                Questions: level.Questions.Select(q => new QuizQuestionDto(
                    Id: q.Id,
                    QuestionText: q.QuestionText,
                    Options: ParseOptions(q.Options),
                    QuestionTextEn: q.QuestionTextEn,
                    OptionsEn: ParseOptions(q.OptionsEn),
                    ImageUrl: q.ImageUrl,
                    CorrrectNptionIndex: q.CorrectOptionIndex
                )).ToList()
            )).ToList();

            return Result<List<GetLevelsResponse>>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<List<GetLevelsResponse>>.Failure($"Error al obtener niveles: {ex.Message}");
        }
    }

    /// <summary>
    /// Parsea las opciones que están almacenadas como TEXT (JSON array) en la base de datos
    /// </summary>
    private static List<string> ParseOptions(string? optionsText)
    {
        if (string.IsNullOrEmpty(optionsText))
            return [];

        try
        {
            return System.Text.Json.JsonSerializer.Deserialize<List<string>>(optionsText) ?? [];
        }
        catch
        {
            // Si no es JSON válido, intentar split por coma
            return optionsText.Split(',', StringSplitOptions.TrimEntries).ToList();
        }
    }
}
