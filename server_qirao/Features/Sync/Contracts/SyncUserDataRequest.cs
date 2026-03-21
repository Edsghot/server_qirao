namespace server_qirao.Features.Sync.Contracts;

public sealed record SyncUserDataRequest(
    UserSyncDto User,
    List<QuizProgressSyncDto> QuizProgress
    );
    
public sealed record UserSyncDto(
    string Id,
    string Name,
    string LastName,
    string Age,
    string KeyAccessUser,
    string Pais,
    string Language,
    bool GamificationEnabled,
    DateTime? LastSyncDate
    );
    
public sealed record QuizProgressSyncDto(
    string Id,
    int Number,
    bool IsLocked,
    bool IsCompleted,
    int Stars,
    int Points,
    List<QuizAnswerSyncDto>? Answers
    );

public sealed record QuizAnswerSyncDto(
    int QuestionId,
    int SelectedOptionIndex,
    bool IsCorrect
    );