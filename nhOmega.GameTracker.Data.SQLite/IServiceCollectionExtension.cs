using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using nhOmega.GameTracker.Core.Repositories;
using nhOmega.GameTracker.Data.SQLite.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace nhOmega.GameTracker.Data.SQLite
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddSqLiteDbContext(this IServiceCollection services, IConfiguration configuration = null)
        {
            string databaseConectionString = null;

            if (configuration is object)
            {
                databaseConectionString = configuration.GetConnectionString("DefaultConnection");
            }

            if (string.IsNullOrEmpty(databaseConectionString))
            {
                databaseConectionString = "Data Source=nhOmega.GameTracker.db;";
            }

            services.AddDbContext<SqLiteContext>(options => options.UseSqlite(databaseConectionString));

            return services;
        }

        public static IServiceCollection AddDataRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGamesRepository, GamesRepository>();

            return services;
        }
    }
}
