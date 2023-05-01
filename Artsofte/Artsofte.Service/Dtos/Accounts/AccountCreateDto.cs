using Artsofte.Domain.Entities;
using Artsofte.Service.Common.Helpers;
using Artsofte.Service.Dtos.Languages;
using System.ComponentModel.DataAnnotations;

namespace Artsofte.Service.Dtos.Accounts
{
    public class AccountCreateDto
    {
        [Required(ErrorMessage = "Enter a name!")]
        public string FirstName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Enter a surname!")]
        public string LastName { get; set; } = String.Empty;

        [Required(ErrorMessage = "Enter a age!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter a department!")]
        public int Department { get; set; }

        [Required(ErrorMessage = "Enter a language!")]
        public string Language { get; set; } = String.Empty;

        public static implicit operator Human(AccountCreateDto accountCreateDto)
        {
            return new Human()
            {
                FirstName = accountCreateDto.FirstName,
                LastName = accountCreateDto.LastName,
                Age = accountCreateDto.Age,
                Department = accountCreateDto.Department,
                Language = accountCreateDto.Language,
                CreatedAt = TimeHelper.GetCurrentServerTime(),
                LastUpdatedAt = TimeHelper.GetCurrentServerTime()
            };
        }
    }
}
