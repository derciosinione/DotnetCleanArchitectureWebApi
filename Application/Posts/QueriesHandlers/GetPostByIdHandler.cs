using Application.Abstractions;
using Application.Posts.Queries;
using Domain.Models;
using MediatR;

namespace Application.Posts.QueriesHandlers;

public class GetPostByIdHandler(IPostRepository repository) : IRequestHandler<GetPostByIdQuery, Post>
{
    public async Task<Post> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await repository.GetPostById(request.PostId);
        return post!;
    }
}