namespace QuizApp.Entities;

public class Attempt
{
    public int AttemptId { get; set; }
    public int QuizId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    
    public virtual Quiz? Quiz { get; set; }
    public virtual ICollection<AttemptAnswer> AttemptAnswers { get; set; } = new List<AttemptAnswer>();
}