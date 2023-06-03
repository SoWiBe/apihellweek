using Extens.Core.Entities;
using Task = Extens.Models.Task;

namespace Extens.Entities;

public class GetTasksEntity : BaseApiResponse
{
    public IEnumerable<Task> Tasks { get; set; }
}