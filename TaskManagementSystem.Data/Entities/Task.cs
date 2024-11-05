namespace TaskManagementSystem.Data.Entities;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int AssignedTo { get; set; } 
    public int StatusId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime DueAt { get; set; }
    public User User { get; set; } 
}