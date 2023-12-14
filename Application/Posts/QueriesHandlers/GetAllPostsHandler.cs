using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueriesHandlers;

public class GetAllPostsHandler(IPostRepository repository) : IRequestHandler<GetAllPostsQuery, ICollection<Post>>
{
    public async Task<ICollection<Post>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await repository.GetAllPosts();
        return posts;
    }
}