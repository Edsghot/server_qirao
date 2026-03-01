namespace server_qirao.Domain.Entities;

public class UserQuizProgress
{
    public int Id { get; set; }
    public required string UserId { get; set; }
    public required string QuizLevelId { get; set; }
    public bool IsLocked { get; set; } = true;
    public bool IsCompleted { get; set; }
    public int Stars { get; set; }
    public int Points { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    // Navigation
    public Usuario Usuario { get; set; } = null!;
    public QuizLevel QuizLevel { get; set; } = null!;
}