using System.Linq.Expressions;
using ChallengesMicroservice.Repository.Core;
using Extens.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = ChallengesMicroservice.Database.DbContext;
using Task = System.Threading.Tasks.Task;

namespace ChallengesMicroservice.Repository;

public class DayTasksRepository : IDayTasksRepository
{
    private readonly DbContext _ctx;
    
    public DayTasksRepository(DbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<DayTask?> GetById(Guid id)
    {
        return await _ctx.DayTasks.FindAsync(id);
    }

    public async Task<IEnumerable<DayTask>?> GetAll()
    {
        return await _ctx.DayTasks.ToListAsync();
    }

    public async Task<IEnumerable<DayTask>?> Find(Expression<Func<DayTask, bool>> expression)
    {
        return _ctx.DayTasks.Where(expression);
    }

    public async Task<DayTask> Add(DayTask entity)
    {
        var result = await _ctx.DayTasks.AddAsync(entity);

        await _ctx.SaveChangesAsync();
        
        return result.Entity;
    }

    public async Task<DayTask> Update(DayTask entity)
    {
        var result = _ctx.DayTasks.Update(entity);

        await _ctx.SaveChangesAsync();
        
        return result.Entity;
    }

    public async Task AddRange(IEnumerable<DayTask> entities)
    {
        await _ctx.DayTasks.AddRangeAsync(entities);

        await _ctx.SaveChangesAsync();
    }

    public async Task Remove(DayTask entity)
    {
        _ctx.DayTasks.Remove(entity);
        
        await _ctx.SaveChangesAsync();
    }

    public async Task RemoveById(Guid id)
    {
        var day = await _ctx.DayTasks.FindAsync(id);

        if (day != null) _ctx.DayTasks.Remove(day);

        await _ctx.SaveChangesAsync();
    }

    public async Task RemoveRange(IEnumerable<DayTask> entities)
    {
        _ctx.DayTasks.RemoveRange(entities);
        
        await _ctx.SaveChangesAsync();
    }

    public async Task RemoveAllTasksForDay(Guid id)
    {
        var dayTasks = _ctx.DayTasks.Where(x => x.DayId.Equals(id)).ToList();
        
        _ctx.DayTasks.RemoveRange(dayTasks);
        
        await _ctx.SaveChangesAsync();
    }
}