using ProductsMarket.DataAccess.Interfaces.Common;
using ProductsMarket.Domain.Entities.Products;

namespace ProductsMarket.DataAccess.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
