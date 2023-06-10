namespace QuizApp.DTOs;

public class ReviewAttemptDto
{
    public int AttemptId { get; set; }
    public int QuizId { get; set; }
    public List<int>? AttemptedAnswers { get; set; }
    public List<GetQuestionDto>? Questions { get; set; }
}