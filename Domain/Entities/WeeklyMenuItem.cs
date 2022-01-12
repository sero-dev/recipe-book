namespace Domain.Entities
{
    public class WeeklyMenuItem
    {
        public int Id { get; set; }
        public string Day { get; set; }

        public int? LunchRecipeId { get; set; }
        public int? DinnerRecipeId { get; set; }
        public Recipe LunchRecipe { get; set; }
        public Recipe DinnerRecipe { get; set; }
        public int Position { get; set; }
    }
}
