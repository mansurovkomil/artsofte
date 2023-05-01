using Artsofte.Domain.Entities;
using Artsofte.Service.Common.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Artsofte.Service.Dtos.Accounts
{
    public class AccountUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name!")]
        public string FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please enter the surname!")]
        public string LastName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Please enter the age!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter the department!")]
        public int Department { get; set; }

        [Required(ErrorMessage = "Please enter the language!")]
        public string Language { get; set; } = String.Empty;

        public static implicit operator Human(AccountUpdateDto accountUpdateDto)
        {
            return new Human()
            {
                FirstName = accountUpdateDto.FirstName,
                LastName = accountUpdateDto.LastName,
                Age = accountUpdateDto.Age,
                Department = accountUpdateDto.Department,
                Language = accountUpdateDto.Language
            };
        }
    }
}
