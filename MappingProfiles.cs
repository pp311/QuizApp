using AutoMapper;
using QuizApp.DTOs;
using QuizApp.Entities;

namespace QuizApp;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Question, GetQuestionDto>();
        CreateMap<Answer, GetAnswerDto>();
        CreateMap<Quiz, DoQuizDto>();
        CreateMap<Attempt, AttemptResultDto>();
        CreateMap<Attempt, ReviewAttemptDto>()
            .ForMember(dto => dto.Questions, opt => opt.MapFrom(attempt => attempt.Quiz.Questions));
    } 
}