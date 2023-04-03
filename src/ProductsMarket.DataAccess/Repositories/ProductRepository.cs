using ProductsMarket.DataAccess.DbContexts;
using ProductsMarket.DataAccess.Interfaces;
using ProductsMarket.DataAccess.Repositories.Common;
using ProductsMarket.Domain.Entities.Products;

namespace ProductsMarket.DataAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
