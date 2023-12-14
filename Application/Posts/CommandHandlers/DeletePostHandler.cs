using Application.Abstractions;
using Application.Posts.Commands;
using MediatR;

namespace Application.Posts.CommandHandlers;

public class DeletePostHandler(IPostRepository repository) : IRequestHandler<DeletePostCommand, bool>
{
    public Task<bool> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    { 
        return repository.DeletePost(request.PostId);
    }
}