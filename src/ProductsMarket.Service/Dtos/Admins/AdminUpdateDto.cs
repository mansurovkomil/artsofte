using ProductsMarket.Domain.Common;
using ProductsMarket.Domain.Entities.Admins;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProductsMarket.Service.Dtos.Admins
{
    public class AdminUpdateDto : BaseEntity
    {
        [Required(ErrorMessage = "Full Name Required")]
        public string FullName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Phone Number Required")]
        [Phone(ErrorMessage = "The phone number was entered incorrectly")]
        [Remote("IsPhoneAvailable", "Check", HttpMethod = "POST", ErrorMessage = "A phone number with this name has already been registered!")]
        public string PhoneNumber { get; set; } = String.Empty;

        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; } = String.Empty;

        public static implicit operator Admin(AdminUpdateDto dto)
        {
            return new Admin()
            {
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                BirthDate = dto.BirthDate,
                Address = dto.Address
            };
        }
    }
}
