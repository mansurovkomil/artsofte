using Artsofte.Service.Dtos.Languages;
using Artsofte.Service.ViewModels.LanguageViewModels;

namespace Artsofte.Service.Interfaces.Languages
{
    public interface ILanguageService
    {
        public Task<bool> AddLanguageAsync(LanguageCreateDto languageCreateDto);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(int id, LanguageUpdateDto languageUpdateDto);
        public Task<List<LanguageViewDto>> GetAllAsync();
        public Task<LanguageViewDto> GetByIdAsync(int id); 
        public IEnumerable<LanguageViewModel> GetLanguageAsync();
    }
}
