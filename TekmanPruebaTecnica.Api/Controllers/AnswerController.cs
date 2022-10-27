using Microsoft.AspNetCore.Mvc;
using TekmanPruebaTecnica.Application.Interfaces;

namespace TekmanPruebaTecnica.Api.Controllers;

[ApiController]
[Route("api")]
public class AnswerController : ControllerBase
{
    private readonly IAnswerService _answerService;

    public AnswerController(IAnswerService answerService)
    {
        _answerService = answerService;
    }

    [HttpPost("user/{userId}/question/{questionId}/answer")]
    public async Task<IActionResult> AnswerQuestion([FromRoute] int userId, [FromRoute] int questionId, [FromBody] string answer)
    {
        var note = await _answerService.AnswerQuestionAsync(userId, questionId, answer);

        return Ok(note);
    }

    [HttpPost("user/{userId}/activity/{activityId}/answer")]
    public async Task<IActionResult> AnswerActivity([FromRoute] int userId, [FromRoute] int activityId, [FromBody] Dictionary<int, string> answerQuestions)
    {
        var note = await _answerService.AnswerActivityAsync(userId, activityId, answerQuestions);

        return Ok(note);
    }
}
