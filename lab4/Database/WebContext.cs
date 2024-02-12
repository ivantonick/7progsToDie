using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Database;

public sealed class WebContext:DbContext
{
    public DbSet<BookDto>? Books { get; set; }

    public WebContext(DbContextOptions<WebContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}
