using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using TaskManagementSystem.Data.Entities;
using Task = TaskManagementSystem.Data.Entities.Task;
using TaskStatus = TaskManagementSystem.Data.Entities.TaskStatus;

namespace TaskManagementSystem.Data;

public class TaskContext(DbContextOptions<TaskContext> options) : DbContext(options)
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<TaskStatus> TaskStatuses { get; set; }
    public DbSet<TaskComment> TaskComments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<TaskContext>
{
    public TaskContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationManager();
        configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var connectionString = configuration.GetConnectionString("TaskContext");
        var optionsBuilder = new DbContextOptionsBuilder<TaskContext>();
        optionsBuilder.UseSqlServer(connectionString);
        return new TaskContext(optionsBuilder.Options);
    }
}
