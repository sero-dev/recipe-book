using Application.ShoppingCart.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.ShoppingCart
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<RecipeIngredient, ShoppingCartItem>()
                .ForMember(dest => dest.Ingredient, src => src.MapFrom(s => s.Ingredient.Name));

            CreateMap<InventoryItem, ShoppingCartItem>()
                .ForMember(dest => dest.Ingredient, src => src.MapFrom(s => s.Ingredient.Name));
        }
    }
}
