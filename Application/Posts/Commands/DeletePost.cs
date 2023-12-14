using Domain.Models;
using MediatR;

namespace Application.Posts.Commands;

public class DeletePost : IRequest<bool>
{
    public Guid PostId { get; set; }
}