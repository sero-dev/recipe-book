using System.Collections.Generic;

namespace Application.ShoppingCart.Queries
{
    public class ShoppingList
    {
        public ShoppingList()
        {
            Required = new List<ShoppingCartItem>();
            Needed = new List<ShoppingCartItem>();
            Inventory = new List<ShoppingCartItem>();
        }

        public List<ShoppingCartItem> Required { get; set; }
        public List<ShoppingCartItem> Needed { get; set; }
        public List<ShoppingCartItem> Inventory { get; set; }
    }
}
