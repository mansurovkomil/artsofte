using Artsofte.DataAccess.DbContexts;
using Artsofte.DataAccess.Interfaces;
using Artsofte.DataAccess.Repositories.Common;
using Artsofte.Domain.Entities;

namespace Artsofte.DataAccess.Repositories
{
    public class DepartamentRepository : GenericRepository<Department>, IDepartamentRepository
    {
        public DepartamentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
