using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe> 
    {
        Task<IEnumerable<Recipe>> GetAllRecipes();
        Task<Recipe> GetFullRecipe(int Id);
        Task UpdateRecipe(Recipe recipe);

    }
}
