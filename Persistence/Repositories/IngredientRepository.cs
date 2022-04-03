using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(RecipeBookContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {
            var ingredients = await ((RecipeBookContext)Context).Ingredients
                .AsNoTracking()
                .OrderBy(r => r.Name)
                .ToListAsync();

            return ingredients;
        }
    }
}
