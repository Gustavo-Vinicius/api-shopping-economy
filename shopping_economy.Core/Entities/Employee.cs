namespace shopping_economy.Core.Entities
{
    public  class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Office { get; set; }

        public decimal Salary { get; set; }

        public DateOnly AdmissionDate { get; set; }

        public int StoreId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public virtual StoreSetup Store { get; set; }
    }
}
