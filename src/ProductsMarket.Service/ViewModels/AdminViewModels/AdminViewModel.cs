using ProductsMarket.Domain.Entities.Admins;

namespace ProductsMarket.Service.ViewModels.AdminViewModels
{
    public class AdminViewModel
    {
        public int Id { get; set; }

        public string FullName { get; set; } = String.Empty;

        public string PhoneNumber { get; set; } = String.Empty;

        public DateTime BirthDate { get; set; } = default!;

        public string Address { get; set; } = String.Empty;

        public DateTime CreatedAt { get; set; } = default!;

        public static implicit operator AdminViewModel(Admin model)
        {
            return new AdminViewModel()
            {
                Id = model.Id,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                BirthDate = model.BirthDate,
                Address = model.Address,
                CreatedAt = model.CreatedAt
            };
        }
    }
}
