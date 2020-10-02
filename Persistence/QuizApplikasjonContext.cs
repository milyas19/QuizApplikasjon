using Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.DBContextConfig;

namespace Persistence
{
    public class QuizApplikasjonContext : DbContext
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }

        public QuizApplikasjonContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new QuizConfig());
            builder.ApplyConfiguration(new QuestionConfig());
            builder.ApplyConfiguration(new ChoiceConfig());

            builder.Entity<Question>().HasData(new Question
            {
                QuestionId = 1,
                QuestionText = "which country won winter olymics",
            });

            builder.Entity<Choice>().HasData(new Choice
            {
                ChoiceId = 1,
                ChoiceText = "Norway",
                QuestionId = 1
                
            });
        }
    }
}
