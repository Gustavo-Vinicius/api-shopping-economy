using Dapper;
using shopping_economy.Core.DTOs;
using shopping_economy.Core.Entities;
using shopping_economy.Core.Interface;
using Microsoft.EntityFrameworkCore;

namespace shopping_economy.Infrastructure.Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataBaseContext _context;

        public ProductRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task InsertProductAsync(Product produto)
        {
            _context.Add(produto);

            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<ProductDTO>> SearchListOfRegisteredProductsAsync()
        {
            var query = "SELECT * FROM Product";

            return await _context.Database.GetDbConnection().QueryAsync<ProductDTO>(query);
        }

        public async Task<Product> SearchProductByIdAsync(int Id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);

            return product;
        }

        public int GetIdAsync()
        {
           var id = _context.Products.OrderByDescending(a => a.Id)
                  .Select(p => p.Id).FirstOrDefault();

            return id;
        }

        public async Task ProductUpdateAsync(ProductDTO product, int id)
        {
            var selectedProduct = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);

            selectedProduct.Update(product.Name, product.Price, product.Description, product.Stock);

            _context.Products.Update(selectedProduct);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var selectedProduct = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);

            _context.Remove(selectedProduct);

            await _context.SaveChangesAsync();
        }
    }
}