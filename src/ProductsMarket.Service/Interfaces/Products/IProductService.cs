using ProductsMarket.Service.Dtos.Admins;
using ProductsMarket.Service.ViewModels.AdminViewModels;
using ProductsMarket.Service.ViewModels.ProductViewModels;

namespace ProductsMarket.Service.Interfaces.Products
{
    public interface IProductService
    {
        public Task<bool> ProductCreatyAsync(ProductViewModel productViewModel);
        public Task<List<ProductViewModel>> GetAllAsync();

        public Task<ProductViewModel> GetByIdAsync(int id);

        public Task<bool> UpdateAsync(int id, ProductViewModel adminUpdatedDto);

        public Task<bool> DeleteAsync(int id);
    }
}
