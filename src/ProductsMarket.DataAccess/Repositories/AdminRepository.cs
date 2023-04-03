using ProductsMarket.DataAccess.DbContexts;
using ProductsMarket.DataAccess.Interfaces;
using ProductsMarket.DataAccess.Repositories.Common;
using ProductsMarket.Domain.Entities.Admins;

namespace ProductsMarket.DataAccess.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
