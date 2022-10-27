using Microsoft.EntityFrameworkCore;
using TekmanPruebaTecnica.Application.Interfaces.Repositories;
using TekmanPruebaTecnica.Domain.Entities;

namespace TekmanPruebaTecnica.Infrastructure.Repositories;

public class ActivityRepository: RepositoryBase, IActivityRepository
{
    public ActivityRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

    public async Task<Activity?> GetAsync(int activityId)
    {
        return await _applicationDbContext.Activities.SingleOrDefaultAsync(a => a.Id == activityId);
    }

    public async Task<Activity?> GetByQuestionIdAsync(int questionId)
    {
        return await _applicationDbContext.Activities.SingleOrDefaultAsync(a => a.Exercices.Any(e => e.Questions.Any(q => q.Id == questionId)));
    }
}
