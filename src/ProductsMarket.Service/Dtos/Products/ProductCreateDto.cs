using ProductsMarket.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace ProductsMarket.Service.Dtos.Products
{
    public class ProductCreateDto : BaseEntity
    {
        [Required(ErrorMessage = "Enter a product title")]
        public string Title { get; set; } = String.Empty; 
        
        [Required(ErrorMessage = "Enter a product quantiy")]
        public int Quantiy { get; set; }

        [Required(ErrorMessage = "Enter a product price")]
        public int Price { get; set; }
    }
}
