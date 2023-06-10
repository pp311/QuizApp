using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizApp.DTOs;
using QuizApp.Services.Interface;

namespace QuizApp.Services;

public class QuestionService : IQuestionService
{
    private readonly QuizAppContext _context;
    private readonly IMapper _mapper;
    public QuestionService(QuizAppContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    
}