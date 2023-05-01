using Artsofte.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Artsofte.DataAccess.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> contextOptions)
            : base(contextOptions)
        {

        }

        public virtual DbSet<Human> Humans { get; set; } = default!;
        public virtual DbSet<Department> Departments { get; set; } = default!;
        public virtual DbSet<Language> Languages { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
