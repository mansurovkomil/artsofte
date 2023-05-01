using Artsofte.Service.Interfaces.Accounts;
using Artsofte.Service.Interfaces.Departments;
using Artsofte.Service.Interfaces.Languages;
using Artsofte.Service.Services.AccountService;
using Artsofte.Service.Services.DepartmentService;
using Artsofte.Service.Services.LanguageService;

namespace Artsofte.Mvc.Configurations.LayerConfigurations
{
    public static class ServiseLayerConfiguration
    {
        public static void AddService(this IServiceCollection services)
        {

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ILanguageService, LanguageService>();

            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(MappingConfiguration));
        }
    }
}
