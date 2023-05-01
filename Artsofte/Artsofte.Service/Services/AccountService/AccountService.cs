using Artsofte.DataAccess.Interfaces.Common;
using Artsofte.Domain.Entities;
using Artsofte.Service.Common.Exceptions;
using Artsofte.Service.Common.Helpers;
using Artsofte.Service.Dtos.Accounts;
using Artsofte.Service.Interfaces.Accounts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Artsofte.Service.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._repository = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var temp = await _repository.Humans.FindByIdAsync(id);
            if (temp is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Account not found");
            _repository.Humans.Delete(id);
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<AccountViewDto>> GetAllAsync()
        {
            var query = _repository.Humans.GetAll().OrderByDescending(x => x.CreatedAt).Select(x => _mapper.Map<AccountViewDto>(x));
            return await query.ToListAsync();
        }

        public async Task<AccountViewDto> GetByIdAsync(int id)
        {
            var temp = await _repository.Humans.FindByIdAsync(id);
            if (temp is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Account is not Found");
            var res = (AccountViewDto)temp;
            return res;
        }

        public async Task<bool> RegisterAccountAsync(AccountCreateDto accountCreateDto)
        {
            var newAccount = (Human)accountCreateDto;

            _repository.Humans.Add(newAccount);
            var dbResult = await _repository.SaveChangesAsync();
            return dbResult > 0;
        }

        public async Task<bool> UpdateAsync(int id, AccountUpdateDto accountUpdateDto)
        {
            var temp = await _repository.Humans.FindByIdAsync(id);
            if (temp is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Account is not found");
            else
            {
                _repository.Humans.TrackingDeteched(temp);
                if (accountUpdateDto != null)
                {
                    temp.FirstName = String.IsNullOrEmpty(accountUpdateDto.FirstName) ? temp.FirstName : accountUpdateDto.FirstName;
                    temp.LastName = String.IsNullOrEmpty(accountUpdateDto.LastName) ? temp.LastName : accountUpdateDto.LastName;
                    if (accountUpdateDto.Age > 0) temp.Age = accountUpdateDto.Age;
                    temp.Language = String.IsNullOrEmpty(accountUpdateDto.Language) ? temp.Language : accountUpdateDto.Language;
                    if (accountUpdateDto.Department > 0) temp.Department = accountUpdateDto.Department;
                }

                temp.LastUpdatedAt = TimeHelper.GetCurrentServerTime();
                _repository.Humans.Update(id, temp);

                var result = await _repository.SaveChangesAsync();
                return result > 0;
            }
        }
    }
}
