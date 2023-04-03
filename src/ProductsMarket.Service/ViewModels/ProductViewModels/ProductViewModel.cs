using ProductsMarket.Domain.Entities.Admins;
using ProductsMarket.Domain.Entities.Products;
using ProductsMarket.Service.ViewModels.AdminViewModels;

namespace ProductsMarket.Service.ViewModels.ProductViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public int Quantiy { get; set; }
        public int Price { get; set; }
        public DateTime CreatedAt { get; set; } = default!;

        public static implicit operator ProductViewModel(Product model)
        {
            return new ProductViewModel()
            {
                Title = model.Title,
                Quantiy = model.Quantiy,
                Price = model.Price,
            };
        }
    }
}
