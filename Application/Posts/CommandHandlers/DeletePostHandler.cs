using Application.Abstractions;
using Application.Posts.Commands;
using Domain.Models;
using MediatR;

namespace Application.Posts.CommandHandlers;

public class DeletePostHandler(IPostRepository repository) : IRequestHandler<DeletePost, bool>
{
    public Task<bool> Handle(DeletePost request, CancellationToken cancellationToken)
    { 
        return repository.DeletePost(request.PostId);
    }
}