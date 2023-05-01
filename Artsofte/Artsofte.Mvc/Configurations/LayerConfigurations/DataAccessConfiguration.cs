using Artsofte.DataAccess.DbContexts;
using Artsofte.DataAccess.Interfaces.Common;
using Artsofte.DataAccess.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Artsofte.Mvc.Configurations.LayerConfigurations
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            string connectionString = configuration.GetConnectionString("DatabaseConnection")!;
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
