using TekmanPruebaTecnica.Domain.Entities;

namespace TekmanPruebaTecnica.Application.Interfaces;

public interface IAnswerService
{
    Task<decimal> AnswerActivityAsync(int userId, int activityId, Dictionary<int, string> answerQuestions);
    Task<decimal> AnswerQuestionAsync(int userId, int questionId, string answer);
    Task<IEnumerable<UserNote>> GetUserNotesAsync(int userId);
}
