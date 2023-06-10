namespace QuizApp.Entities;

public class Quiz
{
   public int QuizId { get; set; }
   public string QuizName { get; set; } = default!;
   public int PassedThreshold { get; set; }
   
   public virtual ICollection<Question> Questions { get; set; } = new List<Question>();   
}