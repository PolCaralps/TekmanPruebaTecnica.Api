using Microsoft.EntityFrameworkCore;
using TekmanPruebaTecnica.Application.Interfaces.Repositories;
using TekmanPruebaTecnica.Domain.Entities;

namespace TekmanPruebaTecnica.Infrastructure.Repositories;

public class UserNoteRepository : RepositoryBase, IUserNoteRepository
{
    public UserNoteRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

    public async Task AddAsync(UserNote userNote) 
    {
        await _applicationDbContext.UserNotes.AddAsync(userNote);
    }

    public async Task<ICollection<UserNote>> GetUserNotesAsync(int userId)
    {
        return await _applicationDbContext.UserNotes.Where(un => un.UserId == userId).ToListAsync();
    }

    public async Task<UserNote?> GetUserNoteQuestionAsync(int userId, int questionId)
    {
        return await _applicationDbContext.UserNotes.SingleOrDefaultAsync(un => un.UserId == userId && un.QuestionId == questionId);
    }
}
