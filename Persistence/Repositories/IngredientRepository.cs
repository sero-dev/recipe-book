using Application.Interfaces;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(RecipeBookContext context) : base(context)
        {
        }
    }
}
