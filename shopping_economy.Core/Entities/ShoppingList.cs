namespace shopping_economy.Core.Entities
{
    public partial class ShoppingList
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string Date { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice { get; set; }

        public int ClientId { get; set; }
    }
}
