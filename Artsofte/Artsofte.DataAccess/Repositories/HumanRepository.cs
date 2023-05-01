using Artsofte.DataAccess.DbContexts;
using Artsofte.DataAccess.Interfaces;
using Artsofte.DataAccess.Repositories.Common;
using Artsofte.Domain.Entities;

namespace Artsofte.DataAccess.Repositories
{
    public class HumanRepository : GenericRepository<Human>, IHumanRepository
    {
        public HumanRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
