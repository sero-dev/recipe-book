using Application.Recipes.Commands;
using Application.Recipes.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Recipes
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeResponse>().ReverseMap();
            CreateMap<RecipeIngredient, RecipeIngredientResponse>().ReverseMap();
            CreateMap<Recipe, RecipeDetailedResponse>().ReverseMap();
            CreateMap<Recipe, CreateRecipeCommand>().ReverseMap();
            CreateMap<Recipe, UpdateRecipeCommand>().ReverseMap();
        }
    }
}
