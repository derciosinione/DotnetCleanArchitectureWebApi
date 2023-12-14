using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers;

public class UpdatePostHandler(IPostRepository repository) : IRequestHandler<UpdatePostCreatePostCommand, Post>
{
    public async Task<Post> Handle(UpdatePostCreatePostCommand request, CancellationToken cancellationToken)
    {
        var postToUpdate = new Post { Content = request.Content };
        var post = await repository.UpdatePost(request.PostId, postToUpdate);
        return post!;
    }
}