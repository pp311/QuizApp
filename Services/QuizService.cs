using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizApp.DTOs;
using QuizApp.Entities;
using QuizApp.Services.Interface;

namespace QuizApp.Services;

public class QuizService : IQuizService
{
    private readonly QuizAppContext _context;
    private readonly IMapper _mapper;
    public QuizService(QuizAppContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<DoQuizDto?> DoQuiz(int quizId)
    {
        var quiz = await _context.Quizzes
            .Include(q => q.Questions)
            .ThenInclude(q => q.Answers)
            .Where(q => q.QuizId == quizId)
            .FirstOrDefaultAsync();
        if (quiz == null)
            return null;
        
        var attempt = new Attempt
        {
            StartTime = DateTime.Now,
            QuizId = quizId
        };
        _context.Attempts.Add(attempt);
        await _context.SaveChangesAsync();
        
        var doQuizDto = _mapper.Map<DoQuizDto>(quiz);
        doQuizDto.AttemptId = attempt.AttemptId;
        doQuizDto.NumberOfQuestions = quiz.Questions.Count;
        //remove correct answer from answers
        foreach (var answer in doQuizDto.Questions.SelectMany(question => question.Answers))
        {
            answer.IsCorrect = null;
        }
        return doQuizDto;
    }
}