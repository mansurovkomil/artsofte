using Artsofte.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Artsofte.Service.Dtos.Languages
{
    public class LanguageUpdateDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name!")]
        public string Name { get; set; } = String.Empty;

        public static implicit operator Language(LanguageUpdateDto languageUpdateDto)
        {
            return new Language()
            {
                Id = languageUpdateDto.Id,
                Name = languageUpdateDto.Name,
            };
        }
    }
}
