using Artsofte.DataAccess.DbContexts;
using Artsofte.DataAccess.Interfaces;
using Artsofte.DataAccess.Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Artsofte.DataAccess.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public IHumanRepository Humans { get; }

        public IDepartamentRepository Departaments { get; }

        public ILanguageRepository Languages { get; }

        public UnitOfWork(AppDbContext appDbContext)
        {
            this.dbContext = appDbContext;

            Humans = new HumanRepository(dbContext);

            Departaments = new DepartamentRepository(dbContext); 
            
            Languages = new LanguageRepository(dbContext);
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
