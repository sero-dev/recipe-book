using Application.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IRecipeService
    {
        RecipeDTO GetRecipeById(int id);
        IEnumerable<RecipeDTO> GetAllRecipes();
        int? AddRecipe(RecipeDTO recipe);
    }
}
