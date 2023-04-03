using ProductsMarket.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ProductsMarket.Service.Dtos.Accounts
{
    public class AccountRegisterDto : AccountLoginDto
    {
        [Required(ErrorMessage = "Enter a phone number!")]
        [PhoneNumber]
        public string PhoneNumber { get; set; } = String.Empty;

        public DateTime BirthDate { get; set; }
    }
}
