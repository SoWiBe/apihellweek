using Extens.Core.Repositories;
using Extens.Models;
using Task = System.Threading.Tasks.Task;

namespace ChallengesMicroservice.Repository.Core;

public interface IDayTasksRepository : IRepository<DayTask>
{
    Task RemoveAllTasksForDay(Guid id);
}