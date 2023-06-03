using Extens.Models;
using Task = Extens.Models.Task;

namespace Extens.Core.Services;

public interface IAggregationService
{
    Task<IEnumerable<Challenge>> AggregateChallenges(IEnumerable<Challenge> challenges, IEnumerable<Day> days, 
        IEnumerable<Task> tasks, IEnumerable<DayTask> dayTasks);
    
    Task<Challenge> AggregateChallenge(Challenge challenge, IEnumerable<Day> days, 
        IEnumerable<Task> tasks, IEnumerable<DayTask> dayTasks);

    Task<IEnumerable<Task>> AggregateDayTasks(IEnumerable<Task> tasks, IEnumerable<DayTask> dayTasks, Guid dayId);
    Task<Day> AggregateDay(Day day, IEnumerable<DayTask> dayTasks, IEnumerable<Task> tasks);
    Task<IEnumerable<Day>> AggregateDays(IEnumerable<Day> days, IEnumerable<DayTask> dayTasks, IEnumerable<Task> tasks);
}