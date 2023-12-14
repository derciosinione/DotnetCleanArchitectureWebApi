using Domain.Models;
using MediatR;

namespace Application.Posts.Commands;

public class CreatePostCommand : IRequest<Post>
{
    public required string Content { get; set; }
}