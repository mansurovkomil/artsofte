using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsMarket.DataAccess.Interfaces.Common;
using ProductsMarket.Domain.Entities.Products;
using ProductsMarket.Service.Common.Exceptions;
using ProductsMarket.Service.Common.Helpers;
using ProductsMarket.Service.Interfaces.Products;
using ProductsMarket.Service.ViewModels.ProductViewModels;

namespace ProductsMarket.Service.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.FindByIdAsync(id);
            if (product is null) throw new NotFoundException("Product", $"{id} not found");
            _unitOfWork.Products.Delete(id);
            int result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<ProductViewModel>> GetAllAsync()
        {
            var query = await _unitOfWork.Products.GetAll().OrderByDescending(x => x.CreatedAt).Select(x => (ProductViewModel)x).ToListAsync();
            return query;
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.FindByIdAsync(id);
            if (product is null) throw new NotFoundException("Product", $"{id} not found");
            var productView = (ProductViewModel)product;
            return productView;
        }

        public async Task<bool> ProductCreatyAsync(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            product.CreatedAt = TimeHelper.GetCurrentServerTime();
            product.LastUpdatedAt = TimeHelper.GetCurrentServerTime();
            _unitOfWork.Products.Add(product);
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> UpdateAsync(int id, ProductViewModel productUpdatedDto)
        {
            var product = await _unitOfWork.Products.FindByIdAsync(id);
            if (product is null) throw new NotFoundException("Product", $"{id} not found");
            _unitOfWork.Products.TrackingDeteched(product);
            if (productUpdatedDto != null)
            {
                product.Title = String.IsNullOrEmpty(productUpdatedDto.Title) ? product.Title : productUpdatedDto.Title;
                product.Quantiy = productUpdatedDto.Quantiy != 0 ? product.Quantiy : productUpdatedDto.Quantiy;
                product.Price = productUpdatedDto.Price != 0 ? product.Price : productUpdatedDto.Price;
                product.LastUpdatedAt = TimeHelper.GetCurrentServerTime();
                _unitOfWork.Products.Update(id, product);
                var result = await _unitOfWork.SaveChangesAsync();
                return result > 0;
            }
            else throw new ModelErrorException("", "Not found");
        }
    }
}
