using ProductsMarket.Domain.Common;
using ProductsMarket.Domain.Entities.Products;

namespace ProductsMarket.Service.Dtos.Products
{
    public class ProductUpdateDto : BaseEntity
    {
        public string Title { get; set; } = String.Empty;
        public int Quantiy { get; set; }
        public int Price { get; set; }

        public static implicit operator Product(ProductUpdateDto dto)
        {
            return new Product()
            {
                Title = dto.Title,
                Quantiy = dto.Quantiy,
                Price = dto.Price
            };
        }
    }
}
