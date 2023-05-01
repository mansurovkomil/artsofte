using Artsofte.DataAccess.DbContexts;
using Artsofte.DataAccess.Interfaces;
using Artsofte.DataAccess.Repositories.Common;
using Artsofte.Domain.Entities;

namespace Artsofte.DataAccess.Repositories
{
    public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
