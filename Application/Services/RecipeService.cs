using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Services
{
    public class RecipeService : IRecipeService
    {
        private IRecipeRepository _repository;
        private IMapper _mapper;

        public RecipeService(IRecipeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public int? AddRecipe(RecipeDTO recipe)
        {
            Recipe newRecipe = _mapper.Map<Recipe>(recipe);
            newRecipe = _repository.Add(newRecipe);

            return newRecipe.Id;
        }

        public IEnumerable<RecipeDTO> GetAllRecipes()
        {
            var items = _repository.GetAll();
            IEnumerable<RecipeDTO> recipes = _mapper.Map<IEnumerable<RecipeDTO>>(items);
            
            return recipes;
        }

        public RecipeDTO GetRecipeById(int id)
        {
            Recipe recipe = _repository.Get(id);

            if (recipe is null) return null;
            
            return _mapper.Map<RecipeDTO>(recipe);
        }
    }
}
