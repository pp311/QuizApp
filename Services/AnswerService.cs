using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizApp.DTOs;
using QuizApp.Services.Interface;

namespace QuizApp.Services;

public class AnswerService : IAnswerService
{
    private readonly QuizAppContext _context;
    private readonly IMapper _mapper;
    public AnswerService(QuizAppContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<ValidateAnswerDto?> ValidateAnswer(int answerId)
    {
        var answer = await _context.Answers.FindAsync(answerId);
        if (answer == null) return null;
        var validateAnswerDto = new ValidateAnswerDto
        {
            AnswerId = answerId
        };
        if (answer!.IsCorrect)
        {
            validateAnswerDto.IsCorrect = true;
            validateAnswerDto.CorrectAnswerId = answer.AnswerId;
        }
        else
        {
            var correctAnswer = await _context.Answers.Where(a => a.QuestionId == answer.QuestionId && a.IsCorrect).FirstOrDefaultAsync();
            validateAnswerDto.IsCorrect = false;
            validateAnswerDto.CorrectAnswerId = correctAnswer!.AnswerId;
        }
        return validateAnswerDto;
    }
}