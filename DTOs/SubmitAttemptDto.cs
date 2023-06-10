namespace QuizApp.DTOs;

public class SubmitAttemptDto
{
    public int AttemptId { get; set; }
    public List<int> Answers { get; set; }
    public DateTime? SubmitTime { get; set; }   
}