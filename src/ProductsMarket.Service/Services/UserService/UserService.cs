using AutoMapper;
using ProductsMarket.DataAccess.Interfaces.Common;
using ProductsMarket.Service.Common.Exceptions;
using ProductsMarket.Service.Common.Helpers;
using ProductsMarket.Service.Common.Security;
using ProductsMarket.Service.Dtos.Accounts;
using ProductsMarket.Service.Dtos.Users;
using ProductsMarket.Service.Interfaces.Common;
using ProductsMarket.Service.Interfaces.Users;
using ProductsMarket.Service.ViewModels.StudentViewModels;
using System.Net;

namespace ProductsMarket.Service.Services.UserService
{
    public class UserService : IUsersService
    {
        private readonly IUnitOfWork _repository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;

        public UserService(IUnitOfWork unitOfWork, IAuthService authService, IMapper mapper, IIdentityService identityService)
        {
            this._repository = unitOfWork;
            this._authService = authService;
            this._mapper = mapper;
            this._identityService = identityService;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _repository.Users.FindByIdAsync(id);
            if (user is null)
            {
                throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found.");
            }
            _repository.Users.Delete(id);
            var res = await _repository.SaveChangesAsync();
            return res > 0;
        }

        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            var student = await _repository.Users.FindByIdAsync(id);
            if (student is null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found!");
            var res = _mapper.Map<UserViewModel>(student);
            return res;
        }

        public async Task<UserViewModel> GetByTokenAsync()
        {
            var user = await _repository.Users.FindByIdAsync(int.Parse(_identityService.Id!.Value.ToString()));
            if (user is null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found!");
            var result = _mapper.Map<UserViewModel>(user);
            return result;
        }

        public async Task<string> LoginAsync(AccountLoginDto accountLoginDto)
        {
            var user = await _repository.Users.FirstOrDefault(x => x.FullName == accountLoginDto.FullName);
            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");
            else
            {
                var passwordHasher = PasswordHasher.Verify(accountLoginDto.Password, user.Salt, user.PasswordHash);
                if (passwordHasher)
                {
                    string token = _authService.GenerateToken(user, "User");
                    return token;
                }
                else throw new StatusCodeException(HttpStatusCode.NotFound, "Incorrect Password");
            }
        }   

        public async Task<bool> UpdateAsync(int id, UserUpdateDto userUpdateDto)
        {
            var user = await _repository.Users.FindByIdAsync(id);
            if (user is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "User is not found");
            else
            {
                _repository.Users.TrackingDeteched(user);
                if (userUpdateDto != null)
                {
                    user.FullName = userUpdateDto.FullName;
                    user.PhoneNumber = userUpdateDto.PhoneNumber;
                    user.BirthDate = userUpdateDto.BirthDate;
                    user.LastUpdatedAt = TimeHelper.GetCurrentServerTime();
                }
                user.LastUpdatedAt = TimeHelper.GetCurrentServerTime();
                _repository.Users.Update(id, user);

                var res = await _repository.SaveChangesAsync();
                return res > 0;
            }
        }
    }
}
