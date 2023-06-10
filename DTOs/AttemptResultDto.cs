namespace QuizApp.DTOs;

public class AttemptResultDto
{
    public int AttemptId { get; set; }
    public int QuizId { get; set; }
    public int Score { get; set; }
    public int NumberOfQuestions { get; set; }
    public int PassedThreshold { get; set; }
    public string? Result { get; set; }
    
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int TotalTime { get; set; }
}