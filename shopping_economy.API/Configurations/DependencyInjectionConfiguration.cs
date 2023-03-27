using shopping_economy.Application.Commands.ProdutoCommand.InserirProduto;
using shopping_economy.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using shopping_economy.Core.Interface;
using shopping_economy.Infrastructure.Persistence.Repository;

namespace shopping_economy.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseNpgsql(configuration.GetConnectionString("connectionNpgsql")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ILoginEmployeeRepository, LoginEmployeeRepository>();
            services.AddScoped<IStoreSetupRepository, StoreSetupRepository>();
            services.AddMediatR(typeof(InserirProdutoCommand));

        }
    }
}