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
        Task<IEnumerable<ProductDTO>> SearchListOfRegisteredProductsAsync();
        Task<Product> SearchProductByIdAsync(int Id);
        Task<int>GetIdAsync();
        Task ProductUpdateAsync(ProductDTO produto, int id);
        Task DeleteProductAsync(int id);
    
    }
}