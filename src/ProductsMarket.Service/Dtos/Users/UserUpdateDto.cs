using ProductsMarket.Domain.Entities.Users;
using ProductsMarket.Service.Common.Helpers;
using ProductsMarket.Service.Dtos.Accounts;

namespace ProductsMarket.Service.Dtos.Users
{
    public class UserUpdateDto : AccountRegisterDto
    {
        public static implicit operator User(UserUpdateDto userUpdateDto)
        {
            return new User()
            {
                FullName = userUpdateDto.FullName,
                PhoneNumber = userUpdateDto.PhoneNumber,
                BirthDate = userUpdateDto.BirthDate,
                CreatedAt = TimeHelper.GetCurrentServerTime(),
                LastUpdatedAt = TimeHelper.GetCurrentServerTime()
            };
        }
    }
}
