using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    }
}
