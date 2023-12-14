using Domain.Models;
using MediatR;

namespace Application.Posts.Commands;

public class DeletePostCommand(Guid id) : IRequest<bool>
{
    public Guid PostId { get; } = id;
}