using System.Net;
using Extens.Core.Services;
using Extens.Entities.Tasks;
using Extens.Errors.Exceptions;
using HellWeekBack.Repository.Core;
using Microsoft.AspNetCore.Mvc;
using CreateTaskRequest = Extens.Entities.CreateTaskRequest;
using GetTaskRequest = Extens.Entities.GetTaskRequest;
using RemoveTaskRequest = Extens.Entities.RemoveTaskRequest;
using Task = Extens.Models.Task;
using UpdateTaskRequest = Extens.Core.Entities.UpdateTaskRequest;

namespace HellWeekBack.Controllers;

[ApiController]
[Route("[controller]/")]
public class TasksController : ControllerBase
{
    private readonly ITasksRepository _tasksRepository;
    private readonly IValidationService _validationService;
    public TasksController(ITasksRepository tasksRepository, 
        IValidationService validationService)
    {
        _tasksRepository = tasksRepository;
        _validationService = validationService;
    }
    
    [HttpGet("GetTask")]
    public async Task<ActionResult<GetTaskResponse>> GetTask(GetTaskRequest request)
    {
        var isNotEmpty = _validationService.CheckNullOrEmpty(new object[] { request.Id });
        if (!isNotEmpty)
            throw new TasksException(HttpStatusCode.BadRequest, "Id is null or empty");

        _validationService.CheckGuid(new object[] { request.Id });

        var task = await _tasksRepository.GetById(new Guid(request.Id));
        
        if(task is null)
            throw new TasksException(HttpStatusCode.NotFound, "Task is not found");
        
        return Ok(new GetTaskResponse { Task = task });
    }
    
    [HttpGet("GetTasks")]
    public async Task<ActionResult<GetTasksResponse>> GetTasks()
    {
        var tasks = await _tasksRepository.GetAll();
        
        if(tasks is null)
            throw new TasksException(HttpStatusCode.NotFound, "Tasks is not found");
        
        return Ok(new GetTasksResponse { Tasks = tasks });
    }

    [HttpPost("CreateTask")]
    public async Task<ActionResult<CreateTaskResponse>> CreateTask(CreateTaskRequest request)
    {
        var isValid = _validationService.CheckNullOrEmpty(new object[]
        {
            request.Title, request.Description, request.Tag
        });

        if (!isValid)
            throw new TasksException(HttpStatusCode.NotFound, "Some fields is null or empty");
        
        var result = await _tasksRepository.Add(new Task()
        {
            Title = request.Title,
            Description = request.Description,
            Tag = request.Tag
        });
        
        return Ok(new CreateTaskResponse { Task = result });
    }

    [HttpPatch("UpdateTask")]
    public async Task<ActionResult<UpdateTaskResponse>> UpdateTask(UpdateTaskRequest request)
    {
        var result = await _tasksRepository.Update(request.Task);
        
        return Ok(new UpdateTaskResponse { Task = result });
    }

    [HttpDelete("RemoveTask")]
    public async Task<ActionResult<RemoveTaskResponse>> Delete(RemoveTaskRequest request)
    {
        var isNotEmpty = _validationService.CheckNullOrEmpty(new object[] { request.Id });
        if (!isNotEmpty)
            throw new TasksException(HttpStatusCode.BadRequest, "Id is null or empty");
        
        _validationService.CheckGuid(new object[] { request.Id });

        await _tasksRepository.RemoveById(new Guid(request.Id));
        
        return Ok(new RemoveTaskResponse { Result = "Success!" });
    }
}