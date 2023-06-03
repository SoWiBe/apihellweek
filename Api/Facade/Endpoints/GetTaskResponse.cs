using Task = Extens.Models.Task;

namespace Facade.Endpoints;

public class GetTaskResponse
{
    public Task Task { get; set; }
}