using Extens.Core.Services;
using Extens.Entities.Challenges;
using Microsoft.AspNetCore.Mvc;

namespace Facade.Controllers;

[ApiController]
[Route("[controller]/")]
public class ChallengesController : ControllerBase
{
    private readonly ILogger<ChallengesController> _logger;

    private readonly IChallengesService _challengesService;
    private readonly IAggregationService _aggregationService;
    private readonly ITasksService _tasksService;
    
    public ChallengesController(ILogger<ChallengesController> logger, IChallengesService challengesService,
        IAggregationService aggregationService, ITasksService tasksService)
    {
        _logger = logger;
        _challengesService = challengesService;
        _aggregationService = aggregationService;
        _tasksService = tasksService;
    }
    
    [HttpGet("GetChallenges")]
    public async Task<ActionResult<GetChallengesResponse>> GetChallenges()
    {
        var challenges = await _challengesService.GetChallenges();
        var days = await _challengesService.GetDays();
        var tasks = await _tasksService.GetTasks();
        var dayTasks = await _challengesService.GetDayTasks();
        
        var result = await _aggregationService.AggregateChallenges(challenges.Challenges, 
            days.Days, tasks.Tasks, dayTasks.DayTasks);
        
        return Ok(new GetChallengesResponse { Challenges = result });
    }
    
    [HttpGet("GetChallenge")]
    public async Task<ActionResult<GetChallengeResponse>> GetChallenge(GetChallengeRequest request)
    {
        var cEntity = await _challengesService.GetChallenge(request);
        var dEntity = await _challengesService.GetDays();
        var tEntity = await _tasksService.GetTasks();
        var dtEntity = await _challengesService.GetDayTasks();
        
        var challenge = await _aggregationService.AggregateChallenge(cEntity.Challenge, 
            dEntity.Days, tEntity.Tasks, dtEntity.DayTasks);

        return Ok(new GetChallengeResponse { Challenge = challenge });
    }

    [HttpPost("CreateChallenge")]
    public async Task<ActionResult<CreateChallengeResponse>> CreateChallenge(CreateChallengeRequest request)
    {
        var result = await _challengesService.CreateChallenge(request);

        return Ok(new CreateChallengeResponse { Challenge = result.Challenge });
    }

    [HttpPatch("UpdateChallenge")]
    public async Task<ActionResult<UpdateChallengeResponse>> UpdateChallenge(UpdateChallengeRequest request)
    {
        var result = await _challengesService.UpdateChallenge(request);

        return Ok(new UpdateChallengeResponse { Challenge = result.Challenge });
    }

    [HttpDelete("RemoveChallenge")]
    public async Task<ActionResult<RemoveChallengeResponse>> RemoveChallenge(RemoveChallengeRequest request)
    {
        var result = await _challengesService.RemoveChallenge(request);

        return Ok(new RemoveChallengeResponse { Result = result.Result });
    }
    
    [HttpPost("CreateDay")]
    public async Task<ActionResult<CreateDayResponse>> CreateDay(CreateDayRequest request)
    {
        var result = await _challengesService.CreateDay(request);

        return Ok(new CreateDayResponse { Day = result.Day });
    }
    
    [HttpGet("GetDays")]
    public async Task<ActionResult<GetDaysResponse>> GetDays()
    {
        var dEntity = await _challengesService.GetDays();
        var dtEntity = await _challengesService.GetDayTasks();
        var tEntity = await _tasksService.GetTasks();
        
        var days = await _aggregationService.AggregateDays(dEntity.Days, dtEntity.DayTasks, tEntity.Tasks);

        return Ok(new GetDaysResponse { Days = days });
    }
    
    [HttpGet("GetDay")]
    public async Task<ActionResult<GetDayResponse>> GetDay(GetDayRequest request)
    {
        var dEntity = await _challengesService.GetDay(request);
        var dtEntity = await _challengesService.GetDayTasks();
        var tEntity = await _tasksService.GetTasks();

        var day = await _aggregationService.AggregateDay(dEntity.Day, dtEntity.DayTasks, tEntity.Tasks);

        return Ok(new GetDayResponse { Day = day });
    }

    [HttpPost("AddTaskInDay")]
    public async Task<ActionResult<AddTaskInDayResponse>> AddTaskInDay(AddTaskInDayRequest request)
    {
        var result = await _challengesService.AddTaskInDay(request);

        return Ok(new AddTaskInDayResponse { Day = result.Day });
    }

    [HttpPatch("UpdateDay")]
    public async Task<ActionResult<UpdateDayResponse>> UpdateDay(UpdateDayRequest request)
    {
        var result = await _challengesService.UpdateDay(request);

        return Ok(new UpdateDayResponse { Day = result.Day });
    }

    [HttpDelete("RemoveDay")]
    public async Task<ActionResult<RemoveDayResponse>> RemoveDay(RemoveDayRequest request)
    {
        var result = await _challengesService.RemoveDay(request);

        return Ok(new RemoveDayResponse() { Result = result.Result });
    }
}