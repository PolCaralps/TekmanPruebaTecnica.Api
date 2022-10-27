using TekmanPruebaTecnica.Application.Interfaces.Repositories;

namespace TekmanPruebaTecnica.Infrastructure.Repositories;

public class SetupRepository : RepositoryBase, ISetupRepository
{
    public SetupRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

    public void Initialize()
    {
        _applicationDbContext.SeedDataBase();
    }
}
