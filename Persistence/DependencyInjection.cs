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
                options.UseSqlite($"Data Source={GetDatabasePath()}");
                options.EnableSensitiveDataLogging();
            });

            return services;
        }

        private static string GetDatabasePath()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}recipebook.db";

            return dbPath;
        }
    }
}
