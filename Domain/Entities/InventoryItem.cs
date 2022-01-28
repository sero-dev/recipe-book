namespace Domain.Entities
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string UnitOfMeasure { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
