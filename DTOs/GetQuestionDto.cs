namespace QuizApp.DTOs;

public class GetQuestionDto
{
    public int QuestionId { get; set; }
    public string? QuestionContent { get; set; }
    public List<GetAnswerDto>? Answers { get; set; }
}