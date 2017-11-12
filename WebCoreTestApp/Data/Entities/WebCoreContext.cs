using Microsoft.EntityFrameworkCore;

namespace WebCoreTestApp.Data.Entities
{
    public class WebCoreContext : DbContext
    {
        public WebCoreContext(DbContextOptions<WebCoreContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}