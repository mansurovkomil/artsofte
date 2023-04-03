using ProductsMarket.Service.Dtos.Accounts;
using ProductsMarket.Service.Dtos.Users;
using ProductsMarket.Service.ViewModels.StudentViewModels;

namespace ProductsMarket.Service.Interfaces.Users
{
    public interface IUsersService
    {
        public Task<bool> DeleteAsync(int id);

        public Task<string> LoginAsync(AccountLoginDto accountLoginDto);
        public Task<bool> UpdateAsync(int id, UserUpdateDto userUpdateDto);

        public Task<UserViewModel> GetByIdAsync(int id);

        public Task<UserViewModel> GetByTokenAsync();
    }
}
