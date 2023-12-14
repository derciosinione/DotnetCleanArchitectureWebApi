using Domain.Models;

namespace Application.Abstractions;

public interface IPostRepository
{
    Task<ICollection<Post>> GetAllPosts();
    Task<Post?> GetPostById(Guid postId);
    Task<Post> CreatePost(Post post);
    Task<Post?> UpdatePost(Guid postId, Post post);
    Task<bool> DeletePost(Guid postId);
}