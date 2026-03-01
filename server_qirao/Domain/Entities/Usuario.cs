namespace server_qirao.Domain.Entities;

public class Usuario
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required string Age { get; set; }
    public required string KeyAccessUser { get; set; }
    public required string Pais { get; set; }
    public required string Language { get; set; }
    public bool GamificationEnabled { get; set; } = true;
    public DateTime? LastSyncDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<UserQuizProgress> QuizProgress { get; set; } = [];
}