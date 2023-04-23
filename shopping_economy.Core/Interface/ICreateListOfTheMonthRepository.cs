using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopping_economy.Core.Entities;

namespace shopping_economy.Core.Interface
{
    public interface ICreateListOfTheMonthRepository
    {
        Task InsertShoppingListAsync(ShoppingList list);
        int GetIdAsync();
        Task<int> GetStockTheProductAsync(string name); 
        Task ProductInventoryUpdateAsync(string name, int newStock);
        Task<decimal> SearchTotalPriceOfTheCurrentMonthAsync(string currentMonth, int client_id);
        Task<decimal> SearchTotalPriceOfTheLastMonthAsync(string lastMonth, int client_id);


    }
}