using Domain.Models;
using MediatR;

namespace Application.Posts.Commands;

public class CreatePostCommand : IRequest<Post>
{
    public string? Content { get; set; }
}