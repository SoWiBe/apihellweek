using Extens.Core.Api;
using Extens.Core.Entities;
using Extens.Core.Services;
using Extens.Entities;
using Facade.Endpoints;
using Microsoft.AspNetCore.Mvc;

namespace Facade.Controllers;

[ApiController]
[Route("[controller]/")]
public class TasksController : ControllerBase
{
    private readonly ITasksService _tasksService;
    
    public TasksController(ITasksService tasksService)
    {
        _tasksService = tasksService;
    }

    [HttpGet("GetTasks")]
    public async Task<ActionResult<GetTasksResponse>> GetTasks()
    {
        var result = await _tasksService.GetTasks();

        return Ok(new GetTasksResponse { Tasks = result.Tasks });
    }
    
    [HttpGet("GetTask")]
    public async Task<ActionResult<GetTaskResponse>> GetTask(GetTaskRequest request)
    {
        var result = await _tasksService.GetTask(request);

        return Ok(new GetTaskResponse { Task = result.Task });
    }

    [HttpPost("CreateTask")]
    public async Task<ActionResult<CreateTaskResponse>> CreateTask(CreateTaskRequest request)
    {
        var result = await _tasksService.CreateTask(request);

        return Ok(new CreateTaskResponse { Task = result.Task });
    }

    [HttpPatch("UpdateTask")]
    public async Task<ActionResult<UpdateTaskResponse>> UpdateTask(UpdateTaskRequest request)
    {
        var result = await _tasksService.UpdateTask(request);

        return Ok(new UpdateTaskResponse { Task = result.Task });
    }

    [HttpDelete("RemoveTask")]
    public async Task<ActionResult<RemoveTaskResponse>> RemoveTask(RemoveTaskRequest request)
    {
        var result = await _tasksService.RemoveTask(request);

        return Ok(new RemoveTaskResponse() { Result = result.Result });
    }
}