namespace WebApi.Requests;

public record UpdatePostRequest
{
    public required string Content { get; set; }
}