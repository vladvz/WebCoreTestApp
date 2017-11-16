using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebCoreTestApp.Data.Entities
{
    public class WebCoreContext : IdentityDbContext<StoreUser>
    {
        public WebCoreContext(DbContextOptions<WebCoreContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}