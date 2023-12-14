using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions opt) : base(opt)
    {
    }

    public DbSet<Post> Posts { get; set; }
    
}