using Domain.Models;
using MediatR;

namespace Application.Posts.Queries;

public class GetPostByIdQuery(Guid postId) : IRequest<Post>
{
    public Guid PostId { get; } = postId;
}