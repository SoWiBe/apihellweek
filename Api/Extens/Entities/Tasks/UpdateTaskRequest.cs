using Task = Extens.Models.Task;

namespace Extens.Entities.Tasks;

public class UpdateTaskRequest
{
    public Task Task { get; set; }
}