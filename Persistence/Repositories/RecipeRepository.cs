using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository 
    {

        public RecipeRepository(RecipeBookContext context) : base(context)
        {

        }

        public async Task<Recipe> GetFullRecipe(int Id)
        {
            var item = await ((RecipeBookContext)Context).Recipes
                .AsNoTracking()
                .Include(r => r.Ingredients)
                    .ThenInclude(i => i.Ingredient)
                .FirstAsync(r => r.Id == Id);

            return item;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipes()
        {
            var recipes = await ((RecipeBookContext)Context).Recipes
                .AsNoTracking()
                .OrderBy(r => r.Name)
                .ToListAsync();

            return recipes;
        }

        public async Task UpdateRecipe(Recipe recipe)
        {
            List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>();
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Recipe = recipe;
                ingredient.RecipeId = recipe.Id;
                recipeIngredients.Add(ingredient);
            }

            recipe.Ingredients = null;
            Context.Update(recipe);

            var ingredientsToDelete = await ((RecipeBookContext)Context).RecipeIngredients
                .Where(r => r.RecipeId == recipe.Id && !recipeIngredients.Select(ri => ri.Id).Contains(r.Id))
                .ToListAsync();

            Context.RemoveRange(ingredientsToDelete);
            Context.UpdateRange(recipeIngredients);
            await Context.SaveChangesAsync();
        }
    }
}
