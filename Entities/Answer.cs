namespace QuizApp.Entities;

public class Answer
{
    public int AnswerId { get; set; }
    public string? AnswerContent { get; set; }
    public int QuestionId { get; set; }
    public bool IsCorrect { get; set; }
    
    public virtual Question? Question { get; set; }
    public virtual ICollection<AttemptAnswer> AttemptAnswers { get; set; } = new List<AttemptAnswer>();
}