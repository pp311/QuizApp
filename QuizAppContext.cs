using Microsoft.EntityFrameworkCore;
using QuizApp.Entities;

namespace QuizApp;

public class QuizAppContext : DbContext
{
    public QuizAppContext(DbContextOptions<QuizAppContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //########## Quiz ##########
        builder.Entity<Quiz>()
            .HasData(
                new Quiz
                {
                    QuizId = 1,
                    QuizName = "Quiz 1",
                    PassedThreshold = 2
                }
            );
        
        //########## Question ##########
        builder.Entity<Question>()
            .Property(q => q.QuestionContent).IsRequired();
        builder.Entity<Question>()
            .HasData(
                new Question
                {
                    QuestionId = 1,
                    QuestionContent = "Question 1",
                    QuizId = 1
                },
                new Question
                {
                    QuestionId = 2,
                    QuestionContent = "Question 2",
                    QuizId = 1
                },
                new Question
                {
                    QuestionId = 3,
                    QuestionContent = "Question 3",
                    QuizId = 1
                }
            );
        //########## Answer ##########
        builder.Entity<Answer>()
            .Property(a => a.AnswerContent).IsRequired();
        builder.Entity<Answer>()
            .HasOne<Question>(a => a.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(a => a.QuestionId);
        builder.Entity<Answer>()
            .HasData(
                new Answer
                {
                    AnswerId = 1,
                    AnswerContent = "Answer 1 for Question 1",
                    QuestionId = 1
                },
                new Answer
                {
                    AnswerId = 2,
                    AnswerContent = "Answer 2 for Question 1",
                    QuestionId = 1,
                    IsCorrect = true
                },
                new Answer
                {
                    AnswerId = 3,
                    AnswerContent = "Answer 3 for Question 1",
                    QuestionId = 1,
                },
                new Answer
                {
                    AnswerId = 4,
                    AnswerContent = "Answer 4 for Question 1",
                    QuestionId = 1,
                },
                new Answer
                {
                    AnswerId = 5,
                    AnswerContent = "Answer 1 for Question 2",
                    QuestionId = 2,
                    IsCorrect = true
                },
                new Answer
                {
                    AnswerId = 6,
                    AnswerContent = "Answer 2 for Question 2",
                    QuestionId = 2,
                },
                new Answer
                {
                    AnswerId = 7,
                    AnswerContent = "Answer 3 for Question 2",
                    QuestionId = 2,
                },
                new Answer
                {
                    AnswerId = 8,
                    AnswerContent = "Answer 4 for Question 2",
                    QuestionId = 2,
                },
                new Answer
                {
                    AnswerId = 9,
                    AnswerContent = "Answer 1 for Question 3",
                    QuestionId = 3
                },
                new Answer
                {
                    AnswerId = 10,
                    AnswerContent = "Answer 2 for Question 3",
                    QuestionId = 3
                },
                new Answer
                {
                    AnswerId = 11,
                    AnswerContent = "Answer 3 for Question 3",
                    QuestionId = 3,
                },
                new Answer
                {
                    AnswerId = 12,
                    AnswerContent = "Answer 4 for Question 3",
                    QuestionId = 3,
                    IsCorrect = true
                }
            );
        
        
        //########## AnswerResult ##########
        builder.Entity<AttemptAnswer>()
            .HasKey(ar => new { ar.AnswerId, ar.AttemptId });
        builder.Entity<AttemptAnswer>()
            .HasOne<Answer>(ar => ar.Answer)
            .WithMany(a => a.AttemptAnswers)
            .HasForeignKey(ar => ar.AnswerId);
        builder.Entity<AttemptAnswer>()
            .HasOne<Attempt>(ar => ar.Attempt)
            .WithMany(r => r.AttemptAnswers)
            .HasForeignKey(ar => ar.AttemptId)
            .OnDelete(DeleteBehavior.NoAction);
    }
    
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Attempt> Attempts { get; set; }
    public DbSet<AttemptAnswer> AttemptAnswers { get; set; }
}