using Application.Recipes.Queries;

namespace Application.WeeklyMenu.Queries
{
    public class WeeklyMenuItemDto
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public RecipeDto Lunch { get; set; }
        public RecipeDto Dinner { get; set; }
    }
}
