using GptBlog.Models;
using Microsoft.EntityFrameworkCore;
namespace GptBlog.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Post> Posts { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=gptBlog.db");
    }
}