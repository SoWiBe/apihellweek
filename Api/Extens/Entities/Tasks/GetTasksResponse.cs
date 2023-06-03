using Extens.Core.Entities;
using Task = Extens.Models.Task;

namespace Extens.Entities.Tasks;

public class GetTasksResponse
{
    public IEnumerable<Task> Tasks { get; set; }
}