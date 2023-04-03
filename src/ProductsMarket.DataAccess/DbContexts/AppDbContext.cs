using Microsoft.EntityFrameworkCore;
using ProductsMarket.Domain.Entities.Admins;
using ProductsMarket.Domain.Entities.Products;
using ProductsMarket.Domain.Entities.Users;

namespace ProductsMarket.DataAccess.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions)
            : base(contextOptions)
        {

        }

        public virtual DbSet<Admin> Admins { get; set; } = default!;
        public virtual DbSet<User> Users { get; set; } = default!;
        public virtual DbSet<Product> Products { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
