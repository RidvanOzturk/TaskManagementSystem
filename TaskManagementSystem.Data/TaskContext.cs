using Microsoft.EntityFrameworkCore;
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
