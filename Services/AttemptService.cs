using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizApp.DTOs;
using QuizApp.Entities;
using QuizApp.Services.Interface;

namespace QuizApp.Services;

public class AttemptService : IAttemptService
{
    private readonly QuizAppContext _context;
    private readonly IMapper _mapper;
    public AttemptService(QuizAppContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AttemptResultDto?> SubmitAttempt(SubmitAttemptDto submitAttemptDto)
    {
        var attempt = await _context.Attempts.FindAsync(submitAttemptDto.AttemptId);
        if (attempt == null)
            return null;
        attempt.EndTime = submitAttemptDto.SubmitTime;
        if (submitAttemptDto.SubmitTime == null)
            attempt.EndTime = DateTime.Now;
        
        var totalQuestions = submitAttemptDto.Answers.Count;
        var totalCorrectAnswers = 0;
        foreach (var answerId in submitAttemptDto.Answers)
        {
           _context.AttemptAnswers.Add(new AttemptAnswer {AttemptId = attempt.AttemptId, AnswerId = answerId}); 
           var answer = await  _context.Answers.FirstOrDefaultAsync(a => a.AnswerId == answerId);
           if(answer.IsCorrect)
               totalCorrectAnswers++;
        }

        await _context.SaveChangesAsync();
        

        var attemptResultDto = _mapper.Map<AttemptResultDto>(attempt);
        attemptResultDto.TotalTime = (int)(attemptResultDto.EndTime - attemptResultDto.StartTime).Value.TotalSeconds;
        attemptResultDto.NumberOfQuestions = totalQuestions;
        attemptResultDto.Score = totalCorrectAnswers;
        
        var quiz = await _context.Quizzes
            .FirstOrDefaultAsync(q => q.QuizId == attempt.QuizId);
        attemptResultDto.Result = quiz.PassedThreshold <= totalCorrectAnswers ? "passed" : "failed";
        attemptResultDto.PassedThreshold = quiz.PassedThreshold;
        return attemptResultDto;
    }

    public async Task<ReviewAttemptDto?> ReviewAttempt(int attemptId)
    {
        var attempt = await _context.Attempts
            .Include(a => a.Quiz)
            .ThenInclude(q => q.Questions)
            .ThenInclude(q => q.Answers)
            .Where(a => a.AttemptId == attemptId)
            .FirstOrDefaultAsync();
        var attemptAnswers = await _context.AttemptAnswers
            .Include(aa => aa.Answer)
            .Where(aa => aa.AttemptId == attemptId)
            .ToListAsync();
        var reviewAttemptDto = _mapper.Map<ReviewAttemptDto>(attempt); 
        reviewAttemptDto.AttemptedAnswers = attemptAnswers.Select(aa => aa.AnswerId).ToList();
        
        return attempt == null ? null : reviewAttemptDto;
    }

}