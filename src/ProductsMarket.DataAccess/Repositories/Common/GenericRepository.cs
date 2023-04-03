using Microsoft.EntityFrameworkCore;
using ProductsMarket.DataAccess.DbContexts;
using ProductsMarket.DataAccess.Interfaces.Common;
using ProductsMarket.Domain.Common;
using System.Linq.Expressions;

namespace ProductsMarket.DataAccess.Repositories.Common
{
    public class GenericRepository<T> : BaseRepository<T>, IGenericRepository<T>
        where T : BaseEntity
    {
        public GenericRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {

        }
        public IQueryable<T> GetAll() => _dbSet;

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate);
    }
}
