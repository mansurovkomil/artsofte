using Microsoft.EntityFrameworkCore;
using ProductsMarket.DataAccess.Interfaces.Common;
using ProductsMarket.Service.Common.Exceptions;
using ProductsMarket.Service.Common.Helpers;
using ProductsMarket.Service.Common.Security;
using ProductsMarket.Service.Dtos.Admins;
using ProductsMarket.Service.Interfaces.Admins;
using ProductsMarket.Service.ViewModels.AdminViewModels;

namespace ProductsMarket.Service.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var admin = await _unitOfWork.Admins.FindByIdAsync(id);
            if (admin is null) throw new NotFoundException("Admin", $"{id} not found");
            _unitOfWork.Admins.Delete(id);
            int result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        public Task<List<AdminViewModel>> GetAllAsync()
        {
            var query = _unitOfWork.Admins.GetAll().OrderByDescending(x => x.CreatedAt).Select(x => (AdminViewModel)x).ToListAsync();
            return query;
        }

        public async Task<AdminViewModel> GetByIdAsync(int id)
        {
            var admin = await _unitOfWork.Admins.FindByIdAsync(id);
            if (admin is null) throw new NotFoundException("Admin", $"{id} not found");
            var adminView = (AdminViewModel)admin;
            return adminView;
        }

        public async Task<AdminViewModel> GetByNameAsync(string name)
        {
            var admin = await _unitOfWork.Admins.FirstOrDefault(x => x.PhoneNumber == name);
            if (admin is null) throw new NotFoundException("Admin", $"{name} not found");
            var adminView = (AdminViewModel)admin;
            return adminView;
        }

        public async Task<bool> UpdateAsync(int id, AdminUpdateDto adminUpdatedDto)
        {
            var admin = await _unitOfWork.Admins.FindByIdAsync(id);
            if (admin is null) throw new NotFoundException("Admin", $"{id} not found");
            _unitOfWork.Admins.TrackingDeteched(admin);
            if (adminUpdatedDto != null)
            {
                admin.FullName = String.IsNullOrEmpty(adminUpdatedDto.FullName) ? admin.FullName : adminUpdatedDto.FullName;
                admin.PhoneNumber = String.IsNullOrEmpty(adminUpdatedDto.PhoneNumber) ? admin.PhoneNumber : adminUpdatedDto.PhoneNumber;
                admin.BirthDate = admin.BirthDate;
                admin.Address = String.IsNullOrEmpty(adminUpdatedDto.Address) ? admin.Address : adminUpdatedDto.Address;
                admin.LastUpdatedAt = TimeHelper.GetCurrentServerTime();
                _unitOfWork.Admins.Update(id, admin);
                var result = await _unitOfWork.SaveChangesAsync();
                return result > 0;
            }
            else throw new ModelErrorException("", "Not found");
        }

        public async Task<bool> UpdatePasswordAsync(int id, PasswordUpdateDto dto)
        {
            var admin = await _unitOfWork.Admins.FindByIdAsync(id);
            if (admin is null)
                throw new StatusCodeException(System.Net.HttpStatusCode.NotFound, "Admin is not found");
            _unitOfWork.Admins.TrackingDeteched(admin);
            var res = PasswordHasher.Verify(dto.OldPassword, admin.Salt, admin.PasswordHash);
            if (res)
            {
                if (dto.NewPassword == dto.VerifyPassword)
                {
                    var hash = PasswordHasher.Hash(dto.NewPassword);
                    admin.PasswordHash = hash.Hash;
                    admin.Salt = hash.Salt;
                    _unitOfWork.Admins.Update(id, admin);
                    var result = await _unitOfWork.SaveChangesAsync();
                    return result > 0;
                }
                else throw new StatusCodeException(System.Net.HttpStatusCode.BadRequest, "new password and verify" + " password must be match!");
            }
            else throw new StatusCodeException(System.Net.HttpStatusCode.BadRequest, "Invalid Password");
        }
    }
}
