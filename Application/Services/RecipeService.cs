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

        public int? AddRecipe(RecipeDto recipe)
        {
            Recipe newRecipe = _mapper.Map<Recipe>(recipe);
            newRecipe = _repository.Add(newRecipe);

            return newRecipe.Id;
        }

        public IEnumerable<RecipeDto> GetAllRecipes()
        {
            var items = _repository.GetAll();
            IEnumerable<RecipeDto> recipes = _mapper.Map<IEnumerable<RecipeDto>>(items);
            
            return recipes;
        }

        public RecipeDto GetRecipeById(int id)
        {
            Recipe recipe = _repository.Get(id);

            if (recipe is null) return null;
            
            return _mapper.Map<RecipeDto>(recipe);
        }
    }
}
