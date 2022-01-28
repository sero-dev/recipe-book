using Application.Interfaces;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class RecipeIngredientRepository : Repository<RecipeIngredient>, IRecipeIngredientRepository
    {
        public RecipeIngredientRepository(RecipeBookContext context) : base(context)
        {
        }
    }
}
