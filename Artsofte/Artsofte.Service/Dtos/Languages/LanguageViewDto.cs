using Artsofte.Domain.Entities;

namespace Artsofte.Service.Dtos.Languages
{
    public class LanguageViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        public static implicit operator LanguageViewDto(Language languageDto)
        {
            return new LanguageViewDto()
            {
                Id = languageDto.Id,
                Name = languageDto.Name,
            };
        }
    }
}
