using Application.WeeklyMenu.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.WeeklyMenu
{
    public class WeeklyMenuProfile : Profile
    {
        public WeeklyMenuProfile()
        {
            CreateMap<WeeklyMenuItem, WeeklyMenuItemDto>()
                .ForMember(d => d.Lunch, s => s.MapFrom(src => src.LunchRecipe))
                .ForMember(d => d.Dinner, s => s.MapFrom(src => src.DinnerRecipe));

            CreateMap<WeeklyMenuItemDto, WeeklyMenuItem>()
                .ForMember(d => d.LunchRecipeId, s => s.MapFrom(src => src.Lunch.Id))
                .ForMember(d => d.DinnerRecipeId, s => s.MapFrom(src => src.Dinner.Id));
        }
    }
}
