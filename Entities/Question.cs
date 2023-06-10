namespace QuizApp.Entities;

public class Question
{
    public int QuestionId { get; set; }
    public string QuestionContent { get; set; } = default!;
    public int QuizId { get; set; }
    
    public virtual Quiz? Quiz { get; set; }
    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
}