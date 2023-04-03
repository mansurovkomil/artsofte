using Microsoft.EntityFrameworkCore;
using ProductsMarket.DataAccess.DbContexts;
using ProductsMarket.DataAccess.Interfaces.Common;
using ProductsMarket.DataAccess.Repositories.Common;

namespace ProductsMarket.Mvc.Configurations.LayerConfigurations
{
    public static class DataAccessConfiguration
    {
        public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DatabaseConnection")!;
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
