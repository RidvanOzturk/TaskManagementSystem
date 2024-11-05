namespace TaskManagementSystem.Data.Entities;

public class TaskUpdate
{
    public int Id { get; set; }
    public int TaskId { get; set; }
    public int NewId { get; set; }
    public int OldId { get; set; }
    public DateTime UpdateAt { get; set; }
    public int UpdatedBy { get; set; }
}
