-- ============================================
-- Script para crear la tabla user_quiz_answers
-- Base de datos: railway (MySQL)
-- Esta tabla faltaba en el script original
-- ============================================

CREATE TABLE IF NOT EXISTS user_quiz_answers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId VARCHAR(36) NOT NULL,
    QuizQuestionId INT NOT NULL,
    QuizLevelId VARCHAR(10) NOT NULL,
    SelectedOptionIndex INT NOT NULL,
    IsCorrect TINYINT(1) NOT NULL DEFAULT 0,
    AnsweredAt DATETIME(6) NOT NULL,
    UNIQUE INDEX IX_user_quiz_answers_UserId_QuizQuestionId (UserId, QuizQuestionId),
    CONSTRAINT FK_user_quiz_answers_usuarios FOREIGN KEY (UserId)
        REFERENCES usuarios(Id) ON DELETE CASCADE,
    CONSTRAINT FK_user_quiz_answers_quiz_questions FOREIGN KEY (QuizQuestionId)
        REFERENCES quiz_questions(Id) ON DELETE CASCADE,
    CONSTRAINT FK_user_quiz_answers_quiz_levels FOREIGN KEY (QuizLevelId)
        REFERENCES quiz_levels(Id) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
