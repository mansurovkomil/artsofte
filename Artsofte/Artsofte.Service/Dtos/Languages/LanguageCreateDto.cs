using Artsofte.Domain.Entities;
using Artsofte.Service.Common.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Artsofte.Service.Dtos.Languages
{
    public class LanguageCreateDto
    {

        [Required(ErrorMessage = "Enter a name!")]
        public string Name { get; set; } = String.Empty;

        public static implicit operator Language(LanguageCreateDto languageCreateDto)
        {
            return new Language()
            {
                Name = languageCreateDto.Name,
            };
        }
    }
}
