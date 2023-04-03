using ProductsMarket.Domain.Common;

namespace ProductsMarket.Domain.Entities
{
    public class Human : Auditable
    {
        public string FullName { get; set; } = String.Empty;

        public string PhoneNumber { get; set; } = String.Empty;

        public DateTime BirthDate { get; set; }
    }
}
