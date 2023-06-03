using Extens.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Facade.Controllers;

[ApiController]
[Route("[controller]/")]
public class FacadeController : ControllerBase
{
    private readonly ILogger<FacadeController> _logger;

    private readonly IChallengesService _challengesService;
    private readonly ITasksService _tasksService;
    private readonly IFacadeService _facadeService;

    public FacadeController(ILogger<FacadeController> logger, IChallengesService challengesService,
        ITasksService tasksService, IFacadeService facadeService)
    {
        _logger = logger;
        _challengesService = challengesService;
        _tasksService = tasksService;
        _facadeService = facadeService;
    }
    
    
}