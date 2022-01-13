using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            services.AddScoped<IIngredientRepository, IngredientRepository>();

            services.AddDbContext<RecipeBookContext>(options => {
                options.UseNpgsql(GetDatabasePath());
                options.LogTo(Console.WriteLine, LogLevel.Information);
            });

            return services;
        }

        private static string GetDatabasePath()
        {
            var host = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? "localhost";
            var database = Environment.GetEnvironmentVariable("DATABASE_DB") ?? "recipebook";
            var username = Environment.GetEnvironmentVariable("DATABASE_USER") ?? "serodev";
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD" ?? "apples123");
            var dbPath = $"Host={host};Database={database};Username={username};Password={password}";

            return dbPath;
        }
    }
}
