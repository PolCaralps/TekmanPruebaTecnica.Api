using TekmanPruebaTecnica.Domain.Entities;

namespace TekmanPruebaTecnica.Application.Interfaces.Repositories;

public interface IUserRepository : IRepository
{
    Task<User?> GetAsync(int id);
    Task<User?> GetWithNotesAsync(int id);
}
