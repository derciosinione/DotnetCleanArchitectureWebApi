namespace WebApi.Requests;

public record CreatePostRequest
{
    public required string Content { get; set; }
}