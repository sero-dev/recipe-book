using Application.Models;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IRecipeService
    {
        RecipeDto GetRecipeById(int id);
        IEnumerable<RecipeDto> GetAllRecipes();
        int? AddRecipe(RecipeDto recipe);
    }
}
