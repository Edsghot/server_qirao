namespace server_qirao.Features.Quiz.Contracts;

public sealed record GetUserResultsResponse(
    string UserId,
    string Name,
    string LastName,
    UserResultsSummary Summary,
    List<LevelResultDto> Levels
);

public sealed record UserResultsSummary(
    int TotalLevels,
    int CompletedLevels,
    int TotalQuestions,
    int CorrectAnswers,
    int WrongAnswers,
    int TotalStars,
    int TotalPoints,
    double AccuracyPercentage
);

public sealed record LevelResultDto(
    string LevelId,
    string LevelName,
    string Mapa,
    bool IsCompleted,
    int Stars,
    int Points,
    List<AnswerResultDto> Answers
);

public sealed record AnswerResultDto(
    int QuestionId,
    string QuestionText,
    string? QuestionTextEn,
    List<string> Options,
    List<string>? OptionsEn,
    int SelectedOptionIndex,
    int CorrectOptionIndex,
    bool IsCorrect,
    DateTime AnsweredAt
);
