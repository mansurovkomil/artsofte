using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductsMarket.DataAccess.DbContexts;
using ProductsMarket.DataAccess.Interfaces;
using ProductsMarket.DataAccess.Interfaces.Common;

namespace ProductsMarket.DataAccess.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public IAdminRepository Admins { get; }
        public IProductRepository Products { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext;

            Admins = new AdminRepository(dbContext);

            Users = new UserRepository(dbContext);

            Products = new ProductRepository(dbContext);
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return dbContext.Entry(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
