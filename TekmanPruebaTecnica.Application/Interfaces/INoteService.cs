using TekmanPruebaTecnica.Domain.Entities;

namespace TekmanPruebaTecnica.Application.Interfaces;

public interface INoteService
{
    Task<decimal> GetFinalYearNote(int userId);
    Task<decimal> GetNoteActivityAsync(int userId, int activityId);
    Task<decimal> GetNoteByCourse(int userId, ActivityCourse course);
}
