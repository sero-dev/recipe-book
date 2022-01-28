using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence.Configurations;

namespace Persistence
{
    public class RecipeBookContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<WeeklyMenuItem> WeeklyMenuItems { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }

        public RecipeBookContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WeeklyMenuItemConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IngredientConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeIngredientConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InventoryItemConfiguration).Assembly);

        }
    }
}
