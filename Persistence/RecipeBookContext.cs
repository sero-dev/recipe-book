using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence
{
    public class RecipeBookContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public string DbPath { get; private set; }

        public RecipeBookContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
