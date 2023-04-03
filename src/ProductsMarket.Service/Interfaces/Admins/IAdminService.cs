using ProductsMarket.Service.Dtos.Admins;
using ProductsMarket.Service.ViewModels.AdminViewModels;

namespace ProductsMarket.Service.Interfaces.Admins
{
    public interface IAdminService
    {
        public Task<AdminViewModel> GetByNameAsync(string name);

        public Task<List<AdminViewModel>> GetAllAsync();

        public Task<AdminViewModel> GetByIdAsync(int id);

        public Task<bool> UpdateAsync(int id, AdminUpdateDto adminUpdatedDto);

        public Task<bool> DeleteAsync(int id);

        public Task<bool> UpdatePasswordAsync(int id, PasswordUpdateDto dto);
    }
}
