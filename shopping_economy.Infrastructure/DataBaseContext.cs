using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using shopping_economy.Core.Entities;

namespace shopping_economy.Infrastructure
{
    public class DataBaseContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataBaseContext(DbContextOptions<DataBaseContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


    /*novas*/
        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<StoreSetup> StoreSetups { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("connectionNpgsql"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}