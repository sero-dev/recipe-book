namespace Domain.Entities
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public double Amount { get; set; }
        public string UnitOfMeasure { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
