using Microsoft.EntityFrameworkCore;
using BasicBlog;
namespace Blogpage.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
