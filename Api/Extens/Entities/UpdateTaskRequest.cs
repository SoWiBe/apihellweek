using Task = Extens.Models.Task;

namespace Extens.Core.Entities;

public class UpdateTaskRequest
{
    public Task Task { get; set; }
}