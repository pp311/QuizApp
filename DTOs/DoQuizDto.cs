namespace QuizApp.DTOs;

public class DoQuizDto
{
    public int QuizId { get; set; }
    public int AttemptId { get; set; }
    public int NumberOfQuestions { get; set; }
    public List<GetQuestionDto>? Questions { get; set; }
    
}