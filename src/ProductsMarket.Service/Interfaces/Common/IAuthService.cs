using ProductsMarket.Domain.Entities;

namespace ProductsMarket.Service.Interfaces.Common
{
    public interface IAuthService
    {
        public string GenerateToken(Human human, string role);
    }
}
