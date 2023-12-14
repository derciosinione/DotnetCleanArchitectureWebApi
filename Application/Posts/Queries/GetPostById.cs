using Domain.Models;
using MediatR;

namespace Application.Posts.Queries;

public class GetPostById(Guid postId) : IRequest<Post>
{
    public Guid PostId { get; } = postId;
}