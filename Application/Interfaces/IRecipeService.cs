using Application.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IRecipeService
    {
        RecipeDTO GetRecipeById(int id);
        IEnumerable<RecipeDTO> GetAllRecipes();
        RecipeDTO AddRecipe(RecipeDTO recipe);
    }
}
