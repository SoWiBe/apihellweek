using System.Linq.Expressions;
using ChallengesMicroservice.Repository.Core;
using Extens.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = ChallengesMicroservice.Database.DbContext;
using Task = System.Threading.Tasks.Task;

namespace ChallengesMicroservice.Repository;

public class DaysRepository : IDayRepository
{
    private readonly DbContext _ctx;
    
    public DaysRepository(DbContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<Day?> GetById(Guid id)
    {
        return await _ctx.Days.FindAsync(id);
    }

    public async Task<IEnumerable<Day>?> GetAll()
    {
        return await _ctx.Days.ToListAsync();
    }

    public async Task<IEnumerable<Day>?> Find(Expression<Func<Day, bool>> expression)
    {
        return _ctx.Days.Where(expression);
    }

    public async Task<Day> Add(Day entity)
    {
        var result = await _ctx.Days.AddAsync(entity);

        await _ctx.SaveChangesAsync();
        
        return result.Entity;
    }

    public async Task<Day> Update(Day entity)
    {
        var result = _ctx.Days.Update(entity);

        await _ctx.SaveChangesAsync();
        
        return result.Entity;
    }

    public async System.Threading.Tasks.Task AddRange(IEnumerable<Day> entities)
    {
        await _ctx.Days.AddRangeAsync(entities);

        await _ctx.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task Remove(Day entity)
    {
        _ctx.Days.Remove(entity);
        
        await _ctx.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task RemoveById(Guid id)
    {
        var day = await _ctx.Days.FindAsync(id);

        if (day != null) _ctx.Days.Remove(day);

        await _ctx.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task RemoveRange(IEnumerable<Day> entities)
    {
        _ctx.Days.RemoveRange(entities);
        
        await _ctx.SaveChangesAsync();
    }
}