using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDTO>()
                .ReverseMap();
        }
    }
}
