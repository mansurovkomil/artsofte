using ProductsMarket.Service.Dtos.Accounts;
using ProductsMarket.Service.Dtos.Admins;

namespace ProductsMarket.Service.Interfaces.Accounts
{
    public interface IAccountService
    {
        public Task<bool> AdminRegisterAsync(AdminRegisterDto adminRegisterDto);
        public Task<string> LoginAsync(AccountLoginDto accountLoginDto);
    }
}
