using Domain.Models;
using MediatR;

namespace Application.Posts.Commands;

public class UpdatePost : IRequest<Post>
{
    public Guid PostId { get; set; }
    public string? Content { get; set; }
}