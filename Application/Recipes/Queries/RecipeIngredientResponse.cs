using Application.Ingredients.Queries;

namespace Application.Recipes.Queries
{
    public class RecipeIngredientResponse
    {
        public int Id { get; set; }
        public IngredientResponse Ingredient { get; set; }
        public string UnitOfMeasure { get; set; }
        public double Amount { get; set; }

    }
}