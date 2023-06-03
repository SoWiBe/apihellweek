using Extens.Models;
using Microsoft.EntityFrameworkCore;
using Task = Extens.Models.Task;

namespace ChallengesMicroservice.Database;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly IConfiguration _configuration;

    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public DbSet<Challenge> Challenges { get; set; }
    public DbSet<Day> Days { get; set; }
    public DbSet<DayTask> DayTasks { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Challenges"));
}