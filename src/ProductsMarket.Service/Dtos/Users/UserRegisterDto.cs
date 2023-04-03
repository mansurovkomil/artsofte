using ProductsMarket.Domain.Entities.Users;
using ProductsMarket.Service.Common.Helpers;
using ProductsMarket.Service.Dtos.Accounts;

namespace ProductsMarket.Service.Dtos.Users
{
    public class UserRegisterDto : AccountRegisterDto
    {
        public static implicit operator User(UserRegisterDto userRegisterDto)
        {
            return new User()
            {

                FullName = userRegisterDto.FullName,
                PhoneNumber = userRegisterDto.PhoneNumber,
                BirthDate = userRegisterDto.BirthDate,
                CreatedAt = TimeHelper.GetCurrentServerTime(),
                LastUpdatedAt = TimeHelper.GetCurrentServerTime(),
            };
        }
    }
}
