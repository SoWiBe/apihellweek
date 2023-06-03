using System.Net;
using ChallengesMicroservice.Repository.Core;
using Extens.Core.Services;
using Extens.Entities.Challenges;
using Extens.Errors.Exceptions;
using Extens.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChallengesMicroservice.Controllers;

[ApiController]
[Route("[controller]/")]
public class ChallengesController : ControllerBase
{
    private readonly IChallengesRepository _challengesRepository;
    private readonly IDayRepository _dayRepository;
    private readonly IDayTasksRepository _dayTasksRepository;
    private readonly IValidationService _validationService;

    public ChallengesController(IChallengesRepository challengesRepository, 
        IDayRepository dayRepository, IDayTasksRepository dayTasksRepository, IValidationService validationService)
    {
        _challengesRepository = challengesRepository;
        _dayRepository = dayRepository;
        _dayTasksRepository = dayTasksRepository;
        _validationService = validationService;
    }

    [HttpGet("GetChallenges")]
    public async Task<ActionResult<GetChallengesResponse>> GetChallenges()
    {
        var challenges = await _challengesRepository.GetAll();
        if (challenges == null)
            throw new ChallengesException(HttpStatusCode.NotFound, "Челленджи не были получены");

        return Ok(new GetChallengesResponse { Challenges = challenges });
    }

    [HttpGet("GetChallenge")]
    public async Task<ActionResult<GetChallengeResponse>> GetChallenge(GetChallengeRequest request)
    {
        _validationService.CheckGuid(new object[] { request.Id });

        var challenge = await _challengesRepository.GetById(new Guid(request.Id));

        return new GetChallengeResponse { Challenge = challenge };
    }

    [HttpPost("CreateChallenge")]
    public async Task<ActionResult<CreateChallengeResponse>> CreateChallenge(CreateChallengeRequest request)
    {
        var isValid = _validationService.CheckNullOrEmpty(new object[]
            { request.Title, request.Description, request.EndDate, request.StartDate});

        if (!isValid)
            throw new ChallengesException(HttpStatusCode.BadRequest, "Some fields is null or empty");
        
        var challenge = await _challengesRepository.Add(new Challenge
        {
            Title = request.Title,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            IsPrivate = request.IsPrivate
        });
        
        return Ok(new CreateChallengeResponse { Challenge = challenge });
    }

    [HttpPatch("UpdateChallenge")]
    public async Task<ActionResult<UpdateChallengeResponse>> UpdateChallenge(UpdateChallengeRequest request)
    {
        var challenge = await _challengesRepository.Update(request.Challenge);

        return Ok(new UpdateChallengeResponse { Challenge = challenge });
    }

    [HttpDelete("RemoveChallenge")]
    public async Task<ActionResult<RemoveChallengeResponse>> RemoveChallenge(RemoveChallengeRequest request)
    {
        _validationService.CheckGuid(new object[] { request.Id });
        
        await _challengesRepository.RemoveById(new Guid(request.Id));
        
        return Ok(new RemoveChallengeResponse { Result = "Success!" });
    }

    [HttpPost("CreateDay")]
    public async Task<ActionResult<CreateDayResponse>> CreateDay(CreateDayRequest request)
    {
        var isValid = _validationService.CheckNullOrEmpty(new object[]
        {
            request.Date, request.Description, request.ChallengeId
        });

        if (!isValid)
           throw new ChallengesException(HttpStatusCode.BadRequest, "Some fields is null or empty");
        
        var day = await _dayRepository.Add(new Day()
        {
            Description = request.Description,
            Date = request.Date,
            ChallengeId = new Guid(request.ChallengeId),
        });
        
        return Ok(new CreateDayResponse { Day = day });
    }

    [HttpPost("AddTaskInDay")]
    public async Task<ActionResult<AddTaskInDayResponse>> AddTaskInDay(AddTaskInDayRequest request)
    {
        var isValid = _validationService.CheckNullOrEmpty(new object[]
        {
            request.DayId, request.TaskId
        });
        
        if (!isValid)
            throw new ChallengesException(HttpStatusCode.BadRequest, "Some fields is null or empty");
        
        var dayTask = await _dayTasksRepository.Add(new DayTask()
        {
            DayId = new Guid(request.DayId),
            TaskId = new Guid(request.TaskId)
        });

        var day = await _dayRepository.GetById(new Guid(request.DayId));
        
        return Ok(new AddTaskInDayResponse { Day = day });
    }

    [HttpGet("GetDay")]
    public async Task<ActionResult<GetDayResponse>> GetDay(GetDayRequest request)
    {
        _validationService.CheckGuid(new object[] { request.Id });
        
        var day = await _dayRepository.GetById(new Guid(request.Id));
        
        if(day is null)
            throw new ChallengesException(HttpStatusCode.NotFound, "Day is not found");

        return Ok(new GetDayResponse { Day = day });
    }
    
    [HttpGet("GetDays")]
    public async Task<ActionResult<GetDaysResponse>> GetDays()
    {
        var days = await _dayRepository.GetAll();
        
        if(days is null)
            throw new ChallengesException(HttpStatusCode.NotFound, "Day is not found");
        
        return Ok(new GetDaysResponse { Days = days });
    }
    
    [HttpPatch("UpdateDay")]
    public async Task<ActionResult<UpdateDayResponse>> UpdateDay(UpdateDayRequest request)
    {
        var day = await _dayRepository.Update(request.Day);

        return Ok(new UpdateDayResponse { Day = day });
    }

    [HttpDelete("RemoveDay")]
    public async Task<ActionResult<RemoveDayResponse>> RemoveDay(RemoveDayRequest request)
    {
        _validationService.CheckGuid(new object[] { request.Id });
        var id = new Guid(request.Id);
        
        await _dayTasksRepository.RemoveAllTasksForDay(id);
        await _dayRepository.RemoveById(id);
        
        return Ok(new RemoveDayResponse { Result = "Success!" });
    }

    [HttpGet("GetDayTasks")]
    public async Task<ActionResult<GetDayTasksResponse>> GetDayTasks()
    {
        var dayTasks = await _dayTasksRepository.GetAll();
        
        if(dayTasks is null)
            throw new ChallengesException(HttpStatusCode.NotFound, "Day tasks is not found");
        
        return Ok(new GetDayTasksResponse { DayTasks = dayTasks });
    }
}