namespace server_qirao.Domain.Entities;

public class QuizQuestion
{
    public int Id { get; set; }
    public required string QuizLevelId { get; set; }
    
    //espanish
    public required string QuestionText { get; set; }
    public required string Options { get; set; }
    
    //English
    public string? QuestionTextEn { get; set; }
    public string? OptionsEn { get; set; }
    
    public required string ImageUrl { get; set; }
    public int CorrectOptionIndex { get; set; }
    
    //Navigation
    public QuizLevel QuizLevel { get; set; } = null!;
}