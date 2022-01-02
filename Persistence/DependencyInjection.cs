using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IWeeklyMenuRepository, WeeklyMenuRepository>();
            services.AddDbContext<RecipeBookContext>(options => {
                options.UseNpgsql(GetDatabasePath());
                options.EnableSensitiveDataLogging();
            });

            return services;
        }

        private static string GetDatabasePath()
        {
            var host = Environment.GetEnvironmentVariable("DATABASE_HOST");
            var database = Environment.GetEnvironmentVariable("DATABASE_DB");
            var username = Environment.GetEnvironmentVariable("DATABASE_USER");
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD");
            var dbPath = $"Host={host};Database={database};Username={username};Password={password}";

            Console.WriteLine(dbPath);

            return dbPath;
        }
    }
}
