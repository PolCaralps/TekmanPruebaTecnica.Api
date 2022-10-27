using TekmanPruebaTecnica.Domain.Entities;

namespace TekmanPruebaTecnica.Application.Interfaces.Repositories;

public interface IUserNoteRepository : IRepository
{
    Task AddAsync(UserNote userNote);
    Task<UserNote?> GetUserNoteQuestionAsync(int userId, int questionId);
    Task<ICollection<UserNote>> GetUserNotesAsync(int userId);
}
