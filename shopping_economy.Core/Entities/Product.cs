namespace shopping_economy.Core.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int StoreId { get; set; }

        public virtual StoreSetup Store { get; set; }


        public void Update(string name, decimal price, string description, int stock)
        {
           Name = name;
           Price = price;
           Description = description;
           Stock = stock;
        }
    }
}
