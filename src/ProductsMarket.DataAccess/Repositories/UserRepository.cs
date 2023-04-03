using ProductsMarket.DataAccess.DbContexts;
using ProductsMarket.DataAccess.Interfaces;
using ProductsMarket.DataAccess.Repositories.Common;
using ProductsMarket.Domain.Entities.Admins;
using ProductsMarket.Domain.Entities.Users;

namespace ProductsMarket.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
