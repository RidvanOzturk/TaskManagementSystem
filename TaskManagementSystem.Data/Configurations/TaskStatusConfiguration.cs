using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Data.Entities;
using TaskStatus = TaskManagementSystem.Data.Entities.TaskStatus;

namespace TaskManagementSystem.Data.Configurations;

public class TaskStatusConfiguration : IEntityTypeConfiguration<TaskStatus>
{
    public void Configure(EntityTypeBuilder<TaskStatus> builder)
    {
        builder.ToTable("TaskStatuses");

        builder.HasKey(ts => ts.Id);

        builder.Property(ts => ts.Name)
               .IsRequired()
               .HasMaxLength(50);
    }
}
