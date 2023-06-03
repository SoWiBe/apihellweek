using Extens.Core.Entities;
using Extens.Models;

namespace Extens.Entities.Challenges;

public class GetDayTasksEntity : BaseApiResponse
{
    public IEnumerable<DayTask> DayTasks { get; set; }
}