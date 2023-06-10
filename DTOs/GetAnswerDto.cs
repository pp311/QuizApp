namespace QuizApp.DTOs;

public class GetAnswerDto
{
    public int AnswerId { get; set; }
    public string? AnswerContent { get; set; }
    public bool? IsCorrect { get; set; }
    
    public bool ShouldSerializeIsCorrect()
    {
        return IsCorrect is not null;
    }
}