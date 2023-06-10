using QuizApp.DTOs;

namespace QuizApp.Services.Interface;

public interface IAttemptService
{
    Task<AttemptResultDto?> SubmitAttempt(SubmitAttemptDto submitAttemptDto);
    Task<ReviewAttemptDto?> ReviewAttempt(int attemptId);
}