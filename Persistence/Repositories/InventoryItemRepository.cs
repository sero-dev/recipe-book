using Application.Interfaces;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class InventoryItemRepository : Repository<InventoryItem>, IInventoryItemRepository 
    {
        public InventoryItemRepository(RecipeBookContext context) : base(context)
        {

        }
    }
}
