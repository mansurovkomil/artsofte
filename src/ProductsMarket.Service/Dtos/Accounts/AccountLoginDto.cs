using ProductsMarket.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ProductsMarket.Service.Dtos.Accounts
{
    public class AccountLoginDto
    {

        [Required(ErrorMessage = "Enter a name!")]
        public string FullName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Enter a password!")]
        [StrongPassword]
        public string Password { get; set; } = String.Empty;
    }
}
