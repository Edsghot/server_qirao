using Microsoft.EntityFrameworkCore;
using server_qirao.Domain.Common;
using server_qirao.Features.Quiz.Contracts;
using server_qirao.Infraestructure.Persistence;

namespace server_qirao.Features.Quiz.GetUserResults;

public class GetUserResultsHandler(AppDbContext dbContext)
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task<Result<GetUserResultsResponse>> HandleAsync(string userId)
    {
        try
        {
            var usuario = await _dbContext.Usuarios
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (usuario is null)
                return Result<GetUserResultsResponse>.Failure("Usuario no encontrado");

            // Obtener progreso por nivel
            var progressList = await _dbContext.UserQuizProgress
                .Where(p => p.UserId == userId)
                .Include(p => p.QuizLevel)
                .OrderBy(p => p.QuizLevel.Number)
                .ToListAsync();

            // Obtener respuestas individuales
            var answers = await _dbContext.UserQuizAnswers
                .Where(a => a.UserId == userId)
                .Include(a => a.QuizQuestion)
                .ToListAsync();

            var levels = new List<LevelResultDto>();

            foreach (var progress in progressList)
            {
                var levelAnswers = answers
                    .Where(a => a.QuizLevelId == progress.QuizLevelId)
                    .Select(a => new AnswerResultDto(
                        QuestionId: a.QuizQuestionId,
                        QuestionText: a.QuizQuestion.QuestionText,
                        QuestionTextEn: a.QuizQuestion.QuestionTextEn,
                        Options: ParseOptions(a.QuizQuestion.Options),
                        OptionsEn: ParseOptions(a.QuizQuestion.OptionsEn),
                        SelectedOptionIndex: a.SelectedOptionIndex,
                        CorrectOptionIndex: a.QuizQuestion.CorrectOptionIndex,
                        IsCorrect: a.IsCorrect,
                        AnsweredAt: a.AnsweredAt
                    ))
                    .ToList();

                levels.Add(new LevelResultDto(
                    LevelId: progress.QuizLevelId,
                    LevelName: progress.QuizLevel.Name,
                    Mapa: progress.QuizLevel.Mapa,
                    IsCompleted: progress.IsCompleted,
                    Stars: progress.Stars,
                    Points: progress.Points,
                    Answers: levelAnswers
                ));
            }

            var totalCorrect = answers.Count(a => a.IsCorrect);
            var totalWrong = answers.Count(a => !a.IsCorrect);
            var totalAnswered = answers.Count;

            var summary = new UserResultsSummary(
                TotalLevels: progressList.Count,
                CompletedLevels: progressList.Count(p => p.IsCompleted),
                TotalQuestions: totalAnswered,
                CorrectAnswers: totalCorrect,
                WrongAnswers: totalWrong,
                TotalStars: progressList.Sum(p => p.Stars),
                TotalPoints: progressList.Sum(p => p.Points),
                AccuracyPercentage: totalAnswered > 0
                    ? Math.Round((double)totalCorrect / totalAnswered * 100, 2)
                    : 0
            );

            var response = new GetUserResultsResponse(
                UserId: userId,
                Name: usuario.Name,
                LastName: usuario.LastName,
                Summary: summary,
                Levels: levels
            );

            return Result<GetUserResultsResponse>.Success(response);
        }
        catch (Exception ex)
        {
            return Result<GetUserResultsResponse>.Failure($"Error al obtener resultados: {ex.Message}");
        }
    }

    private static List<string>? ParseOptions(string? optionsText)
    {
        if (string.IsNullOrEmpty(optionsText))
            return null;

        try
        {
            return System.Text.Json.JsonSerializer.Deserialize<List<string>>(optionsText);
        }
        catch
        {
            return optionsText.Split(',', StringSplitOptions.TrimEntries).ToList();
        }
    }
}
