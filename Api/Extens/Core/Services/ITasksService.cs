using Extens.Core.Entities;
using Extens.Entities;
using Task = Extens.Models.Task;

namespace Extens.Core.Services;

public interface ITasksService
{
    Task<GetTasksEntity> GetTasks();
    Task<GetTaskEntity> GetTask(GetTaskRequest taskRequest);
    Task<CreateTaskEntity> CreateTask(CreateTaskRequest taskRequest);
    Task<UpdateTaskEntity> UpdateTask(UpdateTaskRequest updateTaskRequest);
    Task<RemoveTaskEntity> RemoveTask(RemoveTaskRequest removeTaskRequest);
}