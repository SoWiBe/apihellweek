using Extens.Core.Services;
using Extens.Models;
using Task = Extens.Models.Task;

namespace Extens.Services;

public class AggregationService : IAggregationService
{
    public async Task<IEnumerable<Challenge>> AggregateChallenges(IEnumerable<Challenge> challenges, IEnumerable<Day> days, 
        IEnumerable<Task> tasks, IEnumerable<DayTask> dayTasks)
    {
        var aggDays = new List<Day>();
        var aggChallenges = new List<Challenge>();

        var enumerable = days as Day[] ?? days.ToArray();
        foreach (var day in enumerable)
        {
            var taskIds = dayTasks.Where(x => x.DayId == day.Id);
            day.Tasks = await AggregateDayTasks(tasks, taskIds, day.Id);
            aggDays.Add(day);
        }
        
        foreach (var challenge in challenges)
        {
            challenge.Days = aggDays.Where(x => x.ChallengeId == challenge.Id);
            aggChallenges.Add(challenge);
        }

        return aggChallenges;
    }

    public async Task<Challenge> AggregateChallenge(Challenge challenge, IEnumerable<Day> days, IEnumerable<Task> tasks, IEnumerable<DayTask> dayTasks)
    {
        var aggDays = new List<Day>();
        var aggChallenges = new List<Challenge>();

        var enumerable = days as Day[] ?? days.ToArray();
        foreach (var day in enumerable)
        {
            var taskIds = dayTasks.Where(x => x.DayId == day.Id);
            day.Tasks = await AggregateDayTasks(tasks, taskIds, day.Id);
            aggDays.Add(day);
        }

        challenge.Days = aggDays;

        return challenge;
    }

    public async Task<IEnumerable<Task>> AggregateDayTasks(IEnumerable<Task> tasks, IEnumerable<DayTask> dayTasks, Guid dayId)
    {
        var tasksIds = dayTasks.Where(x => x.DayId == dayId).Select(x => x.TaskId);

        return tasks.Where(x => tasksIds.Contains(x.Id));
    }

    public async Task<Day> AggregateDay(Day day, IEnumerable<DayTask> dayTasks, IEnumerable<Task> tasks)
    {
        day.Tasks = await AggregateDayTasks(tasks, dayTasks, day.Id);

        return day;
    }

    public async Task<IEnumerable<Day>> AggregateDays(IEnumerable<Day> days, IEnumerable<DayTask> dayTasks, IEnumerable<Task> tasks)
    {
        var aggDays = new List<Day>();

        var enumerable = days as Day[] ?? days.ToArray();
        foreach (var day in enumerable)
        {
            var taskIds = dayTasks.Where(x => x.DayId == day.Id);
            day.Tasks = await AggregateDayTasks(tasks, taskIds, day.Id);
            aggDays.Add(day);
        }

        return aggDays;
    }
}