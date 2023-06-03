using Microsoft.EntityFrameworkCore;
using Task = Extens.Models.Task;

namespace HellWeekBack.Database;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    private readonly IConfiguration _configuration;

    public DbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public DbSet<Task> Tasks { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Tasks"));
}