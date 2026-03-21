namespace server_qirao.Domain.Entities;

public class UserQuizAnswer
{
    public int Id { get; set; }
    public required string UserId { get; set; }
    public int QuizQuestionId { get; set; }
    public required string QuizLevelId { get; set; }
    public int SelectedOptionIndex { get; set; }
    public bool IsCorrect { get; set; }
    public DateTime AnsweredAt { get; set; }

    // Navigation
    public Usuario Usuario { get; set; } = null!;
    public QuizQuestion QuizQuestion { get; set; } = null!;
    public QuizLevel QuizLevel { get; set; } = null!;
}
