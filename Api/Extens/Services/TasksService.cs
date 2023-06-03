using System.Net;
using System.Text.Json.Serialization;
using Extens.Core.Api;
using Extens.Core.Entities;
using Extens.Core.Repositories;
using Extens.Core.Services;
using Extens.Entities;
using Extens.Errors;
using Extens.Errors.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Task = Extens.Models.Task;

namespace Extens.Services;

public class TasksService : ITasksService
{
    private readonly IApiRepository _apiRepository;

    public TasksService(IApiRepository apiRepository)
    {
        _apiRepository = apiRepository;
    }

    public async Task<GetTasksEntity> GetTasks()
    {
        var url = "https://localhost:7028/Tasks/GetTasks";
        var result = await _apiRepository.GetResponseAsync(url);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new TasksException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<GetTasksEntity>(content);
        return response;
    }

    public async Task<GetTaskEntity> GetTask(GetTaskRequest taskRequest)
    {
        var url = "https://localhost:7028/Tasks/GetTask";
        var result = await _apiRepository.GetResponseWithDataAsync(url, taskRequest);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK) 
            throw new TasksException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<GetTaskEntity>(content);
        return response;
    }

    public async Task<CreateTaskEntity> CreateTask(CreateTaskRequest taskRequest)
    {
        var url = "https://localhost:7028/Tasks/CreateTask";
        var result = await _apiRepository.PostDataWithResponseAsync(url, taskRequest);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new TasksException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<CreateTaskEntity>(content);
        return response;
    }

    public async Task<UpdateTaskEntity> UpdateTask(UpdateTaskRequest updateTaskRequest)
    {
        var url = "https://localhost:7028/Tasks/UpdateTask";
        var result = await _apiRepository.PatchDataWithResponseAsync(url, updateTaskRequest);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new TasksException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<UpdateTaskEntity>(content);
        return response;
    }

    public async Task<RemoveTaskEntity> RemoveTask(RemoveTaskRequest removeTaskRequest)
    {
        var url = "https://localhost:7028/Tasks/RemoveTask";
        var result = await _apiRepository.DeleteDataWithResponseAsync(url, removeTaskRequest);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new TasksException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<RemoveTaskEntity>(content);
        return response;
    }
    
}