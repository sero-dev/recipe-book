using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ShoppingCart.Queries
{
    public class GetShoppingCartItemsQuery : IRequest<ShoppingList>
    {
        public class GetShoppingCartItemsQueryHandler : IRequestHandler<GetShoppingCartItemsQuery, ShoppingList>
        {
            public IMapper _mapper { get; set; }
            public IWeeklyMenuRepository _menuRepository { get; set; }
            public IInventoryItemRepository _inventoryRepository { get; set; }


            public GetShoppingCartItemsQueryHandler(IMapper mapper, IWeeklyMenuRepository menuRepository, IInventoryItemRepository inventoryRepository)
            {
                _mapper = mapper;
                _menuRepository = menuRepository;
                _inventoryRepository = inventoryRepository;
            }

            public async Task<ShoppingList> Handle(GetShoppingCartItemsQuery request, CancellationToken cancellationToken)
            {
                var requiredIngredients = await _menuRepository.GetShoppingList();
                var obtainedIngredients = await _inventoryRepository.GetAllAsync();
                
                ShoppingList shoppingList = new ShoppingList();
                
                shoppingList.Required = CollectAllIngredients(requiredIngredients);
                shoppingList.Inventory = _mapper.Map<List<ShoppingCartItem>>(obtainedIngredients);
                shoppingList.Needed = FilterIngredientsByInventory(shoppingList.Required, shoppingList.Inventory);

                return shoppingList;
            }

            private List<ShoppingCartItem> FilterIngredientsByInventory(List<ShoppingCartItem> required, List<ShoppingCartItem> inventory)
            {
                List<ShoppingCartItem> items = new List<ShoppingCartItem>();

                foreach (var item in required)
                {
                    ShoppingCartItem exisitingInventoryItem = inventory.Find(i =>
                        i.UnitOfMeasure.Equals(item.UnitOfMeasure, StringComparison.OrdinalIgnoreCase) &&
                        i.Ingredient.Equals(item.Ingredient, StringComparison.OrdinalIgnoreCase));

                    ShoppingCartItem itemToAdd = new ShoppingCartItem()
                    {
                        Ingredient = item.Ingredient,
                        UnitOfMeasure = item.UnitOfMeasure,
                        Amount = exisitingInventoryItem is null ? item.Amount : item.Amount - exisitingInventoryItem.Amount
                    };

                    items.Add(itemToAdd);
                }

                return items;
            }

            private List<ShoppingCartItem> CollectAllIngredients(IEnumerable<WeeklyMenuItem> weeklyMenuItems)
            {
                List<ShoppingCartItem> items = new List<ShoppingCartItem>();

                foreach(var menuItem in weeklyMenuItems)
                {
                    AddIngredientsToCart(items, menuItem.LunchRecipe);
                    AddIngredientsToCart(items, menuItem.DinnerRecipe);
                }

                return items;
            }

            private void AddIngredientsToCart(List<ShoppingCartItem> items, Recipe recipe)
            {
                if (recipe is null) return;
                
                foreach (var ingredient in recipe.Ingredients)
                {
                    ShoppingCartItem itemToBeAdded = _mapper.Map<ShoppingCartItem>(ingredient);

                    ShoppingCartItem exisitingItem = items.Find(i => 
                        i.UnitOfMeasure.Equals(itemToBeAdded.UnitOfMeasure, StringComparison.OrdinalIgnoreCase) && 
                        i.Ingredient.Equals(itemToBeAdded.Ingredient, StringComparison.OrdinalIgnoreCase));

                    if (exisitingItem is null) items.Add(itemToBeAdded);
                    else exisitingItem.Amount += itemToBeAdded.Amount;
                }
                
            }
        }
    }
}
