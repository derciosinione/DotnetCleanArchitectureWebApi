using Application.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class PostRepository(AppDbContext dbContext) : IPostRepository
{
    public async Task<ICollection<Post>> GetAllComments()
    {
        var posts = await  dbContext.Posts.AsNoTracking().ToListAsync();
        return posts;
    }

    public async Task<Post?> GetPostById(Guid postId)
    {
        var post = await  dbContext.Posts.FirstOrDefaultAsync(x=>x.Id==postId);
        return post;
    }

    public async Task<Post> CreatePost(Post post)
    {
        post.CreatedAt = DateTime.UtcNow;
        post.UpdatedAt = DateTime.UtcNow;
        dbContext.Posts.Add(post);
        await dbContext.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> UpdatePost(Guid postId, Post postToUpdate)
    {
        var post = await GetPostById(postId);
        
        if (post is null) return null;
        
        post.Content = postToUpdate.Content;
        post.UpdatedAt = DateTime.UtcNow;
        await dbContext.SaveChangesAsync();

        return post;
    }

    public async Task DeletePost(Guid postId)
    {
        var post = await GetPostById(postId);
        
        if (post is null) return;
        
        dbContext.Posts.Remove(post);
        await dbContext.SaveChangesAsync();
    }
}