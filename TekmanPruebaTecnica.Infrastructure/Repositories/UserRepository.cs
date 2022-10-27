using Microsoft.EntityFrameworkCore;
using TekmanPruebaTecnica.Application.Interfaces.Repositories;
using TekmanPruebaTecnica.Domain.Entities;

namespace TekmanPruebaTecnica.Infrastructure.Repositories;

public class UserRepository : RepositoryBase, IUserRepository 
{
    public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

    public async Task<User?> GetAsync(int id)
    {
        return await _applicationDbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetWithNotesAsync(int id)
    {
        return await _applicationDbContext.Users
            .Include(u => u.Notes)
                .ThenInclude(n => n.Question)
                    .ThenInclude(q => q.Exercice)
                        .ThenInclude(e => e.Activity)
            .SingleOrDefaultAsync(u => u.Id == id);
    }
}
