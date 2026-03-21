-- ============================================
-- Script de creación de tablas para server_qirao
-- Base de datos: railway (MySQL)
-- ============================================

CREATE TABLE IF NOT EXISTS usuarios (
    Id VARCHAR(36) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    Age VARCHAR(10) NOT NULL,
    KeyAccessUser VARCHAR(255) NOT NULL,
    Pais VARCHAR(100) NOT NULL,
    `Language` VARCHAR(10) NOT NULL,
    GamificationEnabled TINYINT(1) NOT NULL DEFAULT 1,
    LastSyncDate DATETIME(6) NULL,
    CreatedAt DATETIME(6) NOT NULL,
    UpdatedAt DATETIME(6) NOT NULL,
    UNIQUE INDEX IX_usuarios_KeyAccessUser (KeyAccessUser)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS quiz_levels (
    Id VARCHAR(10) PRIMARY KEY,
    Number INT NOT NULL,
    Name VARCHAR(100) NOT NULL,
    Mapa VARCHAR(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS quiz_questions (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    QuizLevelId VARCHAR(10) NOT NULL,
    QuestionText VARCHAR(500) NOT NULL,
    Options TEXT NOT NULL,
    QuestionTextEn VARCHAR(500) NULL,
    OptionsEn TEXT NULL,
    ImageUrl VARCHAR(255) NOT NULL,
    CorrectOptionIndex INT NOT NULL,
    CONSTRAINT FK_quiz_questions_quiz_levels FOREIGN KEY (QuizLevelId)
        REFERENCES quiz_levels(Id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

CREATE TABLE IF NOT EXISTS user_quiz_progress (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId VARCHAR(36) NOT NULL,
    QuizLevelId VARCHAR(10) NOT NULL,
    IsLocked TINYINT(1) NOT NULL DEFAULT 1,
    IsCompleted TINYINT(1) NOT NULL DEFAULT 0,
    Stars INT NOT NULL DEFAULT 0,
    Points INT NOT NULL DEFAULT 0,
    UpdatedAt DATETIME(6) NOT NULL,
    UNIQUE INDEX IX_user_quiz_progress_UserId_QuizLevelId (UserId, QuizLevelId),
    CONSTRAINT FK_user_quiz_progress_usuarios FOREIGN KEY (UserId)
        REFERENCES usuarios(Id) ON DELETE CASCADE,
    CONSTRAINT FK_user_quiz_progress_quiz_levels FOREIGN KEY (QuizLevelId)
        REFERENCES quiz_levels(Id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
