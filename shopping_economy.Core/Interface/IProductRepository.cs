using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopping_economy.Core.DTOs;
using shopping_economy.Core.Entities;

namespace shopping_economy.Core.Interface
{
    public interface IProductRepository
    {
        Task InsertProductAsync(Product product);
        Task<List<ProductDTO>> SearchListOfRegisteredProductsAsync(int inicio, int limit);
        Task<Product> SearchProductByIdAsync(int Id);
        int GetIdAsync();
        Task ProductUpdateAsync(ProductDTO produto, int id);
        Task DeleteProductAsync(int id);

        Task<int>GetCountProductsAsync();
    
    }
}