using Artsofte.DataAccess.Interfaces.Common;
using Artsofte.Domain.Entities;
using Artsofte.Service.Common.Exceptions;
using Artsofte.Service.Dtos.Accounts;
using Artsofte.Service.Dtos.Floor;
using Artsofte.Service.Dtos.Languages;
using Artsofte.Service.Interfaces.Languages;
using Artsofte.Service.ViewModels.LanguageViewModels;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Artsofte.Service.Services.LanguageService
{
    public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        public LanguageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._repository = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<bool> AddLanguageAsync(LanguageCreateDto languageCreateDto)
        {
            var newLanguage = (Language)languageCreateDto;

            _repository.Languages.Add(newLanguage);
            var dbResult = await _repository.SaveChangesAsync();
            return dbResult > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var temp = await _repository.Languages.FindByIdAsync(id);
            if (temp is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Language not found");
            _repository.Languages.Delete(id);
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<LanguageViewDto>> GetAllAsync()
        {
            var query = _repository.Languages.GetAll().Select(x => _mapper.Map<LanguageViewDto>(x));
            return await query.ToListAsync();
        }

        public async Task<LanguageViewDto> GetByIdAsync(int id)
        {
            var temp = await _repository.Languages.FindByIdAsync(id);
            if (temp is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Language is not Found");
            var res = (LanguageViewDto)temp;
            return res;
        }

        public IEnumerable<LanguageViewModel> GetLanguageAsync()
        {
            var subjects = _repository.Languages.GetAll();
            var res = subjects.Select(s => _mapper.Map<LanguageViewModel>(s));
            return res;
        }

        public async Task<bool> UpdateAsync(int id, LanguageUpdateDto languageUpdateDto)
        {
            var temp = await _repository.Languages.FindByIdAsync(id);
            if (temp is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Language is not found");
            else
            {
                _repository.Languages.TrackingDeteched(temp);
                if (languageUpdateDto != null)
                {
                    temp.Name = String.IsNullOrEmpty(languageUpdateDto.Name) ? temp.Name : languageUpdateDto.Name;
                }
                _repository.Languages.Update(id, temp);

                var result = await _repository.SaveChangesAsync();
                return result > 0;
            }
        }
    }
}
