using AutoMapper;
using ProductsMarket.DataAccess.Interfaces.Common;
using ProductsMarket.DataAccess.Repositories.Common;
using ProductsMarket.Service.Interfaces.Accounts;
using ProductsMarket.Service.Interfaces.Admins;
using ProductsMarket.Service.Interfaces.Common;
using ProductsMarket.Service.Interfaces.Products;
using ProductsMarket.Service.Interfaces.Users;
using ProductsMarket.Service.Services.AccountService;
using ProductsMarket.Service.Services.AdminService;
using ProductsMarket.Service.Services.Common;
using ProductsMarket.Service.Services.ProductService;
using ProductsMarket.Service.Services.UserService;

namespace ProductsMarket.Mvc.Configurations.LayerConfigurations
{
    public static class ServiseLayerConfiguration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUsersService, UserService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IIdentityService, IdentityService>();

            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MappingConfiguration));
        }
    }
}
