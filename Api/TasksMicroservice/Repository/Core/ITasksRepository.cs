using Extens.Core.Repositories;
using Task = Extens.Models.Task;

namespace HellWeekBack.Repository.Core;

public interface ITasksRepository : IRepository<Task>
{
    
}