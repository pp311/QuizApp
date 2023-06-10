using QuizApp.DTOs;

namespace QuizApp.Services.Interface;

public interface IQuizService
{
    Task<DoQuizDto?> DoQuiz(int quizId);
}