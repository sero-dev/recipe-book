using Application.Interfaces;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository 
    {

        public RecipeRepository(RecipeBookContext context) : base(context)
        {
        }
    }
}
