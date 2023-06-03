using Extens.Models;

namespace Extens.Entities.Challenges;

public class GetDayTasksResponse
{
    public IEnumerable<DayTask> DayTasks { get; set; }
}