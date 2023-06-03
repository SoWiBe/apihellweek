using Task = Extens.Models.Task;

namespace Facade.Endpoints;

public class CreateTaskResponse
{
    public Task Task { get; set; }
}