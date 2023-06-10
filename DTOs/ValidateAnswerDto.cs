namespace QuizApp.DTOs;

public class ValidateAnswerDto
{
    public int AnswerId { get; set; }
    public int CorrectAnswerId { get; set; }
    public bool IsCorrect { get; set; }
}