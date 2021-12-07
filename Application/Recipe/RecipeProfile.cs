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
            CreateMap<Recipe, RecipeDto>().ReverseMap();
            CreateMap<Recipe, CreateRecipeCommand>().ReverseMap();
            CreateMap<Recipe, UpdateRecipeCommand>().ReverseMap();
        }
    }
}
