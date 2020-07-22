using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.Data
{
    public class WebApiDemoContext : DbContext
    {
        public WebApiDemoContext (DbContextOptions<WebApiDemoContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
