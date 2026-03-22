using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server_qirao.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Las tablas ya existen en la base de datos.
            // Esta migración vacía registra el estado inicial
            // para que EF Core sepa que ya están creadas.
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "user_quiz_progress");
            migrationBuilder.DropTable(name: "quiz_questions");
            migrationBuilder.DropTable(name: "quiz_levels");
            migrationBuilder.DropTable(name: "usuarios");
        }
    }
}
