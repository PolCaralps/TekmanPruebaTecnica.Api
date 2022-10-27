using TekmanPruebaTecnica.Application.Interfaces;
using TekmanPruebaTecnica.Application.Interfaces.Repositories;

namespace TekmanPruebaTecnica.Application.Services;

public class SetupApplicationService : ISetupApplicationService
{
    private readonly ISetupRepository _setupRepository;

    public SetupApplicationService(ISetupRepository setupRepository)
    {
        _setupRepository = setupRepository ?? throw new ArgumentNullException(nameof(ISetupRepository));
    }

    public void Initialize()
    {
        _setupRepository.Initialize();
    }
}
