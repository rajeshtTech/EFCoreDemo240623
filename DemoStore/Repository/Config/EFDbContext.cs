using DemoStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoStore.Repository
{
    public class EFDbContext: DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options): base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
    