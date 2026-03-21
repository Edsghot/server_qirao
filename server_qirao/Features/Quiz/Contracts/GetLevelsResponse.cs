namespace server_qirao.Features.Quiz.Contracts;

public record GetLevelsResponse(
    string Id,
    int Number,
    string Name,
    string Mapa,
    List<QuizQuestionDto> Questions
    );
    
    public sealed record QuizQuestionDto(
        int Id,
        string QuestionText,
        List<string> Options,
        string? QuestionTextEn,
        List<string> OptionsEn,
        string ImageUrl,
        int CorrrectNptionIndex
        );