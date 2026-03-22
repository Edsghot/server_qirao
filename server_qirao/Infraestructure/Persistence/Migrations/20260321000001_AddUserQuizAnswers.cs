using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_qirao.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserQuizAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_quiz_answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuizQuestionId = table.Column<int>(type: "int", nullable: false),
                    QuizLevelId = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SelectedOptionIndex = table.Column<int>(type: "int", nullable: false),
                    IsCorrect = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AnsweredAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_quiz_answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_quiz_answers_usuarios_UserId",
                        column: x => x.UserId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_quiz_answers_quiz_questions_QuizQuestionId",
                        column: x => x.QuizQuestionId,
                        principalTable: "quiz_questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_quiz_answers_quiz_levels_QuizLevelId",
                        column: x => x.QuizLevelId,
                        principalTable: "quiz_levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_user_quiz_answers_UserId_QuizQuestionId",
                table: "user_quiz_answers",
                columns: new[] { "UserId", "QuizQuestionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_quiz_answers_QuizQuestionId",
                table: "user_quiz_answers",
                column: "QuizQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_user_quiz_answers_QuizLevelId",
                table: "user_quiz_answers",
                column: "QuizLevelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "user_quiz_answers");
        }
    }
}
