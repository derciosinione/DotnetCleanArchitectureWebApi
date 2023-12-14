using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _dbContext;

    public PostRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ICollection<Post>> GetAllComments()
    {
        var posts = await  _dbContext.Posts.AsNoTracking().ToListAsync();
        return posts;
    }

    public async Task<Post?> GetPostById(Guid postId)
    {
        var post = await  _dbContext.Posts.FirstOrDefaultAsync(x=>x.Id==postId);
        return post;
    }

    public async Task<Post> CreatePost(Post post)
    {
        post.CreatedAt = DateTime.UtcNow;
        post.UpdatedAt = DateTime.UtcNow;
        _dbContext.Posts.Add(post);
        await _dbContext.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> UpdatePost(Guid postId, Post postToUpdate)
    {
        var post = await GetPostById(postId);
        
        if (post is null) return null;
        
        post.Content = postToUpdate.Content;
        post.UpdatedAt = DateTime.UtcNow;
        await _dbContext.SaveChangesAsync();

        return post;
    }

    public async Task DeletePost(Guid postId)
    {
        var post = await GetPostById(postId);
        
        if (post is null) return;
        
        _dbContext.Posts.Remove(post);
        await _dbContext.SaveChangesAsync();
    }
}