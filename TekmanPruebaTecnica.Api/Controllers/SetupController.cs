using Microsoft.AspNetCore.Mvc;
using TekmanPruebaTecnica.Application.Interfaces;
using TekmanPruebaTecnica.Application.Services;

namespace TekmanPruebaTecnica.Api.Controllers;

public class SetupController : ControllerBase
{
	private AppSettings _appSettings;
	private readonly ISetupApplicationService _setupApplicationService;

	public SetupController(AppSettings appSettings,
		ISetupApplicationService setupApplicationService)
	{
        _appSettings = appSettings ?? throw new ArgumentNullException(nameof(AppSettings));
        _setupApplicationService = setupApplicationService ?? throw new ArgumentNullException(nameof(ISetupApplicationService));
	}

	[HttpGet("setup")]
	public IActionResult Initialize()
	{
		_setupApplicationService.Initialize();

		return NoContent();
	}

    [HttpPut("settings")]
    public IActionResult UpdateSettings([FromBody] AppSettings appSettings)
    {
		_appSettings.PercentageActivity = appSettings.PercentageActivity;
        _appSettings.PercentatgeExercice = appSettings.PercentatgeExercice;
        _appSettings.PercentatgeSelfEvaluation = appSettings.PercentatgeSelfEvaluation;
        _appSettings.PercentatgeTest = appSettings.PercentatgeTest;

        _appSettings.PercentageSocial = appSettings.PercentageSocial;
        _appSettings.PercentatgeDigital = appSettings.PercentatgeDigital;
        _appSettings.PercentatgeMaths = appSettings.PercentatgeMaths;

        return NoContent();
    }
}
