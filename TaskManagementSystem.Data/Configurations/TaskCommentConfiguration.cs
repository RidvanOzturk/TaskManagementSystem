using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagementSystem.Data.Entities;
using Task = TaskManagementSystem.Data.Entities.Task;

namespace TaskManagementSystem.Data.Configurations;

public class TaskCommentConfiguration : IEntityTypeConfiguration<TaskComment>
{
    public void Configure(EntityTypeBuilder<TaskComment> builder)
    {
        builder.ToTable("TaskComments");

        builder.HasKey(tc => tc.Id);

        builder.Property(tc => tc.Comment)
               .IsRequired()
               .HasMaxLength(500);

        builder.HasOne<Task>()
               .WithMany()
               .HasForeignKey(tc => tc.TaskId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(tc => tc.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.Property(tc => tc.CommentAt)
               .HasDefaultValueSql("GETDATE()");
    }
}
