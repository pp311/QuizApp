namespace QuizApp.Entities;

public class AttemptAnswer
{
    public int AnswerId { get; set; }
    public int AttemptId { get; set; }
    
    public virtual Answer? Answer { get; set; }
    public virtual Attempt? Attempt { get; set; }
}