namespace shopping_economy.Core.Entities
{
    public partial class StoreSetup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Manager { get; set; }

        public TimeOnly OpeningHours { get; set; }

        public TimeOnly ClosingTime { get; set; }

        public virtual ICollection<Employee> Employees { get; } = new List<Employee>();

        public virtual ICollection<Product> Products { get; } = new List<Product>();
    }
}
