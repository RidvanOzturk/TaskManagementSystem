using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Data.Entities;
using Task = TaskManagementSystem.Data.Entities.Task;

namespace TaskManagementSystem.Data.Configurations;

public class TaskUpdateConfiguration : IEntityTypeConfiguration<TaskUpdate>
{
    public void Configure(EntityTypeBuilder<TaskUpdate> builder)
    {
        builder.ToTable("TaskUpdates");

        builder.HasKey(tu => tu.Id);

        builder.HasOne<Task>()
               .WithMany()
               .HasForeignKey(tu => tu.TaskId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(tu => tu.NewId)
               .IsRequired();

        builder.Property(tu => tu.OldId)
               .IsRequired();

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(tu => tu.UpdatedBy)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(tu => tu.UpdateAt)
               .HasDefaultValueSql("GETDATE()");
    }
}
