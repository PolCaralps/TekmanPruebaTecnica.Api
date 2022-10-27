using TekmanPruebaTecnica.Application.Interfaces.Repositories;

namespace TekmanPruebaTecnica.Infrastructure.Repositories;

public abstract class RepositoryBase : IRepository
{
    protected readonly ApplicationDbContext _applicationDbContext;

    public RepositoryBase(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(ApplicationDbContext));
    }

    public async Task SaveChangesAsync() 
    {
        await _applicationDbContext.SaveChangesAsync();
    }
}
