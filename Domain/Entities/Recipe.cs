using System.Collections.Generic;

namespace Domain.Entities
{
  public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; }
    }
}
