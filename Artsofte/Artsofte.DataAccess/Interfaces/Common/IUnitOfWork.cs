using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Artsofte.DataAccess.Interfaces.Common
{
    public interface IUnitOfWork
    {
        public IHumanRepository Humans { get; }
        public IDepartamentRepository Departaments { get; }
        public ILanguageRepository Languages { get; }
        public Task<int> SaveChangesAsync();
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
