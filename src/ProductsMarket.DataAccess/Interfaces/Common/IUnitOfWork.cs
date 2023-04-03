using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ProductsMarket.DataAccess.Interfaces.Common
{
    public interface IUnitOfWork
    {
        public IAdminRepository Admins { get; }
        public IProductRepository Products { get; }
        public IUserRepository Users { get; }
        public Task<int> SaveChangesAsync();
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
