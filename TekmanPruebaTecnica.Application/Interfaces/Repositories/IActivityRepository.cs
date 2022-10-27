using TekmanPruebaTecnica.Domain.Entities;

namespace TekmanPruebaTecnica.Application.Interfaces.Repositories;

public interface IActivityRepository : IRepository
{
    Task<Activity?> GetAsync(int activityId);
    Task<Activity?> GetByQuestionIdAsync(int questionId);
}
