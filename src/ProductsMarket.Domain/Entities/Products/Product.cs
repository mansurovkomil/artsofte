using ProductsMarket.Domain.Common;

namespace ProductsMarket.Domain.Entities.Products
{
    public class Product : Auditable
    {
        public string Title { get; set; } = String.Empty;
        public int Quantiy { get; set; }
        public int Price { get; set; }
    }
}
