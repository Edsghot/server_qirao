using Microsoft.EntityFrameworkCore;
using server_qirao.Domain.Entities;

namespace server_qirao.Infraestructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) 
{
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<QuizLevel> QuizLevels => Set<QuizLevel>();
        public DbSet<QuizQuestion> QuizQuestions => Set<QuizQuestion>();
        public DbSet<UserQuizProgress> UserQuizProgress => Set<UserQuizProgress>();
        public DbSet<UserQuizAnswer> UserQuizAnswers => Set<UserQuizAnswer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder.Entity<Usuario>(entity =>
                {
                        entity.ToTable("usuarios");
                        entity.HasKey(e => e.Id);
                        entity.Property(e => e.Id).HasMaxLength(36);
                        entity.Property(e => e.Name).HasMaxLength(100);
                        entity.Property(e => e.LastName).HasMaxLength(100);
                        entity.Property(e => e.Age).HasMaxLength(10);
                        entity.Property(e => e.KeyAccessUser).HasMaxLength(255);
                        entity.Property(e => e.Pais).HasMaxLength(100);
                        entity.Property(e => e.Language).HasMaxLength(10);
                        
                        entity.HasIndex(e => e.KeyAccessUser).IsUnique(); // Esto es para que no se repita el Key AccessUser
                });

                modelBuilder.Entity<QuizLevel>(entity =>
                {
                        entity.ToTable("quiz_levels");
                        entity.HasKey(e => e.Id);
                        entity.Property(e => e.Id).HasMaxLength(10);
                        entity.Property(e => e.Name).HasMaxLength(100);
                        entity.Property(e => e.Mapa).HasMaxLength(50);
                        
                        entity.HasMany( e => e.Questions)
                                .WithOne( q => q.QuizLevel)
                                .HasForeignKey(q => q.QuizLevelId)
                                .OnDelete(DeleteBehavior.Cascade);
                });

                modelBuilder.Entity<QuizQuestion>(entity =>
                {
                        entity.ToTable("quiz_questions");
                        entity.HasKey(e => e.Id);
                        entity.Property(e => e.QuestionText).HasMaxLength(500);
                        entity.Property(e => e.QuestionTextEn).HasMaxLength(500);
                        entity.Property(e => e.Options).HasColumnType("TEXT");
                        entity.Property(e => e.OptionsEn).HasColumnType("TEXT");
                        entity.Property(e => e.ImageUrl).HasMaxLength(255);
                });

                modelBuilder.Entity<UserQuizProgress>(entity =>
                {
                        entity.ToTable("user_quiz_progress");
                        entity.HasKey(e => e.Id);

                        entity.HasIndex(e => new { e.UserId, e.QuizLevelId }).IsUnique(); 
                        
                        entity.HasOne( e => e.Usuario)
                                .WithMany( u => u.QuizProgress)
                                .HasForeignKey(e => e.UserId)
                                .OnDelete(DeleteBehavior.Cascade);
                        
                        entity.HasOne(e => e.QuizLevel)
                                .WithMany(l => l.UserProgress)
                                .HasForeignKey(e => e.QuizLevelId)
                                .OnDelete(DeleteBehavior.Cascade);
                });

                modelBuilder.Entity<UserQuizAnswer>(entity =>
                {
                        entity.ToTable("user_quiz_answers");
                        entity.HasKey(e => e.Id);

                        // Un usuario solo puede responder una pregunta una vez (si vuelve a jugar, se actualiza)
                        entity.HasIndex(e => new { e.UserId, e.QuizQuestionId }).IsUnique();

                        entity.HasOne(e => e.Usuario)
                                .WithMany()
                                .HasForeignKey(e => e.UserId)
                                .OnDelete(DeleteBehavior.Cascade);

                        entity.HasOne(e => e.QuizQuestion)
                                .WithMany()
                                .HasForeignKey(e => e.QuizQuestionId)
                                .OnDelete(DeleteBehavior.Cascade);

                        entity.HasOne(e => e.QuizLevel)
                                .WithMany()
                                .HasForeignKey(e => e.QuizLevelId)
                                .OnDelete(DeleteBehavior.Cascade);
                });
        }
}