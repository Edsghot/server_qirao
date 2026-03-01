namespace server_qirao.Features.Sync.Contracts;

public record SyncUserDataResponse(
    bool Success,
    string Message,
    DateTime SyncedAt
    );