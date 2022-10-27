using Microsoft.AspNetCore.Mvc;
using TekmanPruebaTecnica.Application.Interfaces;
using TekmanPruebaTecnica.Domain.Entities;

namespace TekmanPruebaTecnica.Api.Controllers;

[ApiController]
[Route("api")]
public class NoteController : ControllerBase
{
    private readonly INoteService _noteService;

    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpGet("user/{userId}/activity/{activityId}/note")]
    public async Task<IActionResult> GetNoteActivity([FromRoute] int userId, [FromRoute] int activityId)
    {
        var note = await _noteService.GetNoteActivityAsync(userId, activityId);

        return Ok(note);
    }

    [HttpGet("user/{userId}/course/{course}/note")]
    public async Task<IActionResult> GetNotesByCourse([FromRoute] int userId, ActivityCourse course)
    {
        var note = await _noteService.GetNoteByCourse(userId, course);

        return Ok(note);
    }

    [HttpGet("user/{userId}/finalnotes")]
    public async Task<IActionResult> GetNotesByCourse([FromRoute] int userId)
    {
        var note = await _noteService.GetFinalYearNote(userId);

        return Ok(note);
    }
}
