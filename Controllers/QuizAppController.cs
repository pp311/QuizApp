using Microsoft.AspNetCore.Mvc;
using QuizApp.DTOs;
using QuizApp.Services.Interface;

namespace QuizApp.Controllers;

[ApiController]
[Route("api/")]
public class QuizAppController : ControllerBase
{
    private readonly IQuizService _quizService;
    private readonly IAnswerService _answerService;
    private readonly IAttemptService _attemptService;
    
    public QuizAppController(IQuizService quizService, IAnswerService answerService, IAttemptService attemptService)
    {
        _quizService = quizService;
        _answerService = answerService;
        _attemptService = attemptService;
    }
    
    [HttpPost("do-quiz/{quizId:int?}")]
    public async Task<ActionResult<List<DoQuizDto>>> DoQuiz(int quizId = 1)
    {
        var result = await _quizService.DoQuiz(quizId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
    
    [HttpGet("validate-answer/{answerId:int}")]
    public async Task<ActionResult<ValidateAnswerDto>> ValidateAnswer(int answerId)
    {
        var result = await _answerService.ValidateAnswer(answerId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
    
    [HttpPost("submit-attempt")]
    public async Task<ActionResult<AttemptResultDto>> SubmitAttempt(SubmitAttemptDto? submitAttemptDto)
    {
        if (submitAttemptDto == null)
            return BadRequest();
        var result = await _attemptService.SubmitAttempt(submitAttemptDto);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
    
    [HttpGet("review-attempt/{attemptId:int}")]
    public async Task<ActionResult<ReviewAttemptDto>> ReviewAttempt(int attemptId)
    {
        var result = await _attemptService.ReviewAttempt(attemptId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}