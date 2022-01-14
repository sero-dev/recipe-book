using Application.Recipes.Queries;

namespace Application.WeeklyMenu.Queries
{
    public class WeeklyMenuItemDto
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public RecipeResponse Lunch { get; set; }
        public RecipeResponse Dinner { get; set; }
    }
}
