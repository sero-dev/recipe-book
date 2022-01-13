using Application.Ingredients.Commands;
using Application.Ingredients.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Ingredients
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>().ReverseMap();
            CreateMap<Ingredient, CreateIngredientCommand>().ReverseMap();
            CreateMap<Ingredient, UpdateIngredientCommand>().ReverseMap();
        }
    }
}
