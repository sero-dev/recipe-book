using Application.Models;
using AutoMapper;

namespace Application.Mappings
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<RecipeProfile, RecipeDTO>();
        }
    }
}
