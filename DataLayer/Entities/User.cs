namespace TaskManagementSystem.Data.Entities;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string PasswordHash { get; set; }
    public required string Role { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Task> Tasks { get; set; }  
}
