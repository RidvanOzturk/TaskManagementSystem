using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Data.Entities;
using Task = TaskManagementSystem.Data.Entities.Task;
using TaskStatus = TaskManagementSystem.Data.Entities.TaskStatus;
namespace TaskManagementSystem.Data.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.ToTable("Tasks");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(t => t.Description)
               .HasMaxLength(500);

        builder.Property(t => t.AssignedTo)
               .HasMaxLength(50);

        builder.HasOne(t => t.User)
               .WithMany(u => u.Tasks)
               .HasForeignKey(t => t.AssignedTo)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<TaskStatus>()
               .WithMany()
               .HasForeignKey(t => t.StatusId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(t => t.CreatedAt)
               .HasDefaultValueSql("GETDATE()");

        builder.Property(t => t.DueAt);
    }
}
