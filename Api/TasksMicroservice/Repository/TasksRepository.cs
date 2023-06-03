using System.Linq.Expressions;
using Extens.Core.Repositories;
using Extens.Repositories;
using HellWeekBack.Repository.Core;
using Microsoft.EntityFrameworkCore;
using DbContext = HellWeekBack.Database.DbContext;
using Task = Extens.Models.Task;


namespace HellWeekBack.Repository;

public class TasksRepository : ITasksRepository
{
    private readonly DbContext _ctx;
    
    public TasksRepository(DbContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<Task?> GetById(Guid id)
    {
        return await _ctx.Tasks.FindAsync(id);
    }

    public async Task<IEnumerable<Task>?> GetAll()
    {
        return await _ctx.Tasks.ToListAsync();
    }

    public async Task<IEnumerable<Task>?> Find(Expression<Func<Task, bool>> expression)
    {
        return _ctx.Tasks.Where(expression);
    }

    public async Task<Task> Add(Task entity)
    {
        var result = await _ctx.Tasks.AddAsync(entity);

        await _ctx.SaveChangesAsync();
        
        return result.Entity;
    }

    public async Task<Task> Update(Task entity)
    {
        var result = _ctx.Tasks.Update(entity);

        await _ctx.SaveChangesAsync();
        
        return result.Entity;
    }

    public async System.Threading.Tasks.Task AddRange(IEnumerable<Task> entities)
    {
        await _ctx.Tasks.AddRangeAsync(entities);

        await _ctx.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task Remove(Task entity)
    {
        _ctx.Tasks.Remove(entity);
        
        await _ctx.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task RemoveById(Guid id)
    {
        var task = await _ctx.Tasks.FindAsync(id);

        if (task != null) _ctx.Tasks.Remove(task);

        await _ctx.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task RemoveRange(IEnumerable<Task> entities)
    {
        _ctx.Tasks.RemoveRange(entities);
        
        await _ctx.SaveChangesAsync();
    }
}