using Artsofte.Service.Dtos.Accounts;
using Artsofte.Service.ViewModels.AccountViewModels;

namespace Artsofte.Service.Interfaces.Accounts
{
    public interface IAccountService
    {
        public Task<bool> RegisterAccountAsync(AccountCreateDto accountCreateDto);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> UpdateAsync(int id, AccountUpdateDto accountUpdateDto);
        public Task<List<AccountViewDto>> GetAllAsync();
        public Task<AccountViewDto> GetByIdAsync(int id);
    }
}
