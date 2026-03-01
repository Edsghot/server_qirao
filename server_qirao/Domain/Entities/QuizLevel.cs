namespace server_qirao.Domain.Entities;

public class QuizLevel
{
    public required string Id { get; set; }
    public int Number { get; set; }
    public required string Name { get; set; }
    public required string Mapa { get; set; }
    
    //relaciones con otros entities
    public List<QuizQuestion> Questions { get; set; } = [];
    public List<UserQuizProgress> UserProgress { get; set; } = [];
}