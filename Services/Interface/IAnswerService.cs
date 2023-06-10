using QuizApp.DTOs;

namespace QuizApp.Services.Interface;

public interface IAnswerService
{
    Task<ValidateAnswerDto?> ValidateAnswer(int answerId);
}