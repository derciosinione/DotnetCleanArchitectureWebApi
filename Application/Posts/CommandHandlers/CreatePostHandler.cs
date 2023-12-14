using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers;

public class CreatePostHandler(IPostRepository repository) : IRequestHandler<CreatePost, Post>
{
    public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
    {
        var newPost = new Post { Content = request.Content };
        var post = await repository.CreatePost(newPost);
        return post;
    }
}