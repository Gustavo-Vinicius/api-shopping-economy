using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.EntityFrameworkCore;
using shopping_economy.Core.Entities;
using shopping_economy.Core.Interface;

namespace shopping_economy.Infrastructure.Persistence.Repository
{
    public class CreateListOfTheMonthRepository : ICreateListOfTheMonthRepository
    {
        private readonly DataBaseContext _context;
        public CreateListOfTheMonthRepository(DataBaseContext context)
        {
            _context = context;
        }

        public int GetIdAsync()
        {
            var id = _context.ShoppingLists.OrderByDescending(a => a.Id)
                 .Select(p => p.Id).FirstOrDefault();

            return id;
        }
        public async Task InsertShoppingListAsync(ShoppingList list)
        {
            _context.Add(list);

            await _context.SaveChangesAsync();
        }
        public async Task<int> GetStockTheProductAsync(string name)
        {
            var query = "SELECT product.stock  FROM product WHERE name = @name";

            return await _context.Database.GetDbConnection().QueryFirstOrDefaultAsync<int>(query, new { name });

        }

        public async Task ProductInventoryUpdateAsync(string name, int newStock)
        {
            var queryUpdate = "UPDATE product SET stock = @newStock WHERE name = @name";

            await _context.Database.GetDbConnection().ExecuteAsync(queryUpdate, new { name, newStock });
        }

        public async Task<decimal> SearchTotalPriceOfTheCurrentMonthAsync(string currentMonth)
        {
           var query = "SELECT Sum(total_price) FROM shopping_list WHERE shopping_list.date = @currentMonth";

           return await _context.Database.GetDbConnection().QueryFirstOrDefaultAsync<decimal>(query, new {currentMonth});
        }

        public async Task<decimal> SearchTotalPriceOfTheLastMonthAsync(string lastMonth)
        {
            var query = "SELECT Sum(total_price) FROM shopping_list WHERE shopping_list.date = @lastMonth";

           return await _context.Database.GetDbConnection().QueryFirstOrDefaultAsync<decimal>(query, new {lastMonth});
        }
    }
}
