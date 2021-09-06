﻿using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Persistence.Configurations;

namespace Persistence
{
    public class RecipeBookContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public RecipeBookContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeConfiguration).Assembly);
        }
    }
}
