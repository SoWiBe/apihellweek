using Task = Extens.Models.Task;

namespace Facade.Endpoints;

public class GetTasksResponse
{
    public IEnumerable<Task> Tasks { get; set; }
}