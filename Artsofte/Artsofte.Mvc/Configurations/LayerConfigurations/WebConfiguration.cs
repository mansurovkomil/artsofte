﻿namespace Artsofte.Mvc.Configurations.LayerConfigurations
{
    public static class WebConfiguration
    {
        public static void AddWeb(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureAuth(configuration);
        }
    }
}