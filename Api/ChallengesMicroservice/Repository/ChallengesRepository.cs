using System.Linq.Expressions;
using ChallengesMicroservice.Repository.Core;
using Extens.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = ChallengesMicroservice.Database.DbContext;
using Task = System.Threading.Tasks.Task;

namespace ChallengesMicroservice.Repository;

public class ChallengesRepository : IChallengesRepository
{
    private readonly DbContext _ctx;
    
    public ChallengesRepository(DbContext ctx)
    {
        _ctx = ctx;
    }
    
    public async Task<Challenge?> GetById(Guid id)
    {
        return await _ctx.Challenges.FindAsync(id);
    }

    public async Task<IEnumerable<Challenge>?> GetAll()
    {
        return await _ctx.Challenges.ToListAsync();
    }

    public async Task<IEnumerable<Challenge>?> Find(Expression<Func<Challenge, bool>> expression)
    {
        return _ctx.Challenges.Where(expression);
    }

    public async Task<Challenge> Add(Challenge entity)
    {
        var result = await _ctx.Challenges.AddAsync(entity);

        await _ctx.SaveChangesAsync();
        
        return result.Entity;
    }

    public async Task<Challenge> Update(Challenge entity)
    {
        var result = _ctx.Challenges.Update(entity);

        await _ctx.SaveChangesAsync();
        
        return result.Entity;
    }

    public async System.Threading.Tasks.Task AddRange(IEnumerable<Challenge> entities)
    {
        await _ctx.Challenges.AddRangeAsync(entities);

        await _ctx.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task Remove(Challenge entity)
    {
        _ctx.Challenges.Remove(entity);
        
        await _ctx.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task RemoveById(Guid id)
    {
        var challenge = await _ctx.Challenges.FindAsync(id);

        if (challenge != null) _ctx.Challenges.Remove(challenge);

        await _ctx.SaveChangesAsync();
    }

    public async System.Threading.Tasks.Task RemoveRange(IEnumerable<Challenge> entities)
    {
        _ctx.Challenges.RemoveRange(entities);
        
        await _ctx.SaveChangesAsync();
    }
}