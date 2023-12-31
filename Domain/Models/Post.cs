namespace Domain.Models;

public class Post
{
    public Guid Id { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}