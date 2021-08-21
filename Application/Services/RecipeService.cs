using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepository _repository;

        public RecipeService(IRecipeRepository repository)
        {
            _repository = repository;
        }

        public RecipeDTO AddRecipe(RecipeDTO recipe)
        {
            Recipe newRecipe = new Recipe
            {
                Name = recipe.Name
            };

            Recipe savedRecipe = _repository.Add(newRecipe);
            recipe.Id = savedRecipe.Id;

            return recipe;
        }

        public IEnumerable<RecipeDTO> GetAllRecipes()
        {
            return new List<RecipeDTO>()
            {
                new RecipeDTO()
                {
                    Id = 1,
                    Name = "Pizza"
                },
                new RecipeDTO()
                {
                    Id = 2,
                    Name = "Tacos"
                }
            };
        }

        public RecipeDTO GetRecipeById(int id)
        {
            Recipe recipe = _repository.Get(id);

            if (recipe is null) return null;

            RecipeDTO r = new RecipeDTO
            {
                Id = recipe.Id,
                Name = recipe.Name
            };

            return r;
        }
    }
}
