using AutoMapper;
using ProductsMarket.DataAccess.Interfaces.Common;
using ProductsMarket.Domain.Entities.Admins;
using ProductsMarket.Service.Common.Exceptions;
using ProductsMarket.Service.Common.Helpers;
using ProductsMarket.Service.Common.Security;
using ProductsMarket.Service.Dtos.Accounts;
using ProductsMarket.Service.Dtos.Admins;
using ProductsMarket.Service.Interfaces.Accounts;
using ProductsMarket.Service.Interfaces.Common;

namespace ProductsMarket.Service.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _repository;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork, IAuthService authService, IMapper mapper)
        {
            this._repository = unitOfWork;
            this._authService = authService;
            this._mapper = mapper;
        }
        public async Task<bool> AdminRegisterAsync(AdminRegisterDto adminRegisterDto)
        {
            var fullNameCheck = await _repository.Admins.FirstOrDefault(x => x.FullName == adminRegisterDto.FullName);
            if (fullNameCheck is not null)
                throw new AlreadyExistingException(nameof(adminRegisterDto.FullName), "This full name is already registered.");

            var hashresult = PasswordHasher.Hash(adminRegisterDto.Password);
            var admin = _mapper.Map<Admin>(adminRegisterDto);
            admin.PasswordHash = hashresult.Hash;
            admin.Salt = hashresult.Salt;
            admin.CreatedAt = TimeHelper.GetCurrentServerTime();
            admin.LastUpdatedAt = TimeHelper.GetCurrentServerTime();
            _repository.Admins.Add(admin);
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }

        public async Task<string> LoginAsync(AccountLoginDto accountLoginDto)
        {
            var admin = await _repository.Admins.FirstOrDefault(x => x.FullName == accountLoginDto.FullName);
            if (admin is null)
            {
                var user = await _repository.Users.FirstOrDefault(x => x.FullName == accountLoginDto.FullName);
                if (user is null) throw new NotFoundException(nameof(accountLoginDto.FullName), "No user with this full name is found!");
                else
                {
                    var hasherResult = PasswordHasher.Verify(accountLoginDto.Password, user.Salt, user.PasswordHash);
                    if (hasherResult)
                    {
                        string token = _authService.GenerateToken(user, "user");
                        return token;
                    }
                    else throw new NotFoundException(nameof(accountLoginDto.Password), "Incorrect password!");
                }

            }
            else
            {
                var hasherResult = PasswordHasher.Verify(accountLoginDto.Password, admin.Salt, admin.PasswordHash);
                if (hasherResult)
                {
                    string token = "";
                    if (admin.FullName != null)
                    {
                        token = _authService.GenerateToken(admin, "admin");
                        return token;
                    }
                    token = _authService.GenerateToken(admin, "admin");
                    return token;
                }
                else throw new NotFoundException(nameof(accountLoginDto.Password), "Incorrect password!");
            }
        }
    }
}
