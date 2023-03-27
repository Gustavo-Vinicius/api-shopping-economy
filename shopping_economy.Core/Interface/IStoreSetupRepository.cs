using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopping_economy.Core.DTOs;
using shopping_economy.Core.Entities;

namespace shopping_economy.Core.Interface
{
    public interface IStoreSetupRepository
    {
        Task InsertStoreSetupAsync(StoreSetup storeSetup);
        Task<IEnumerable<StoreSetupDTO>> SearchListOfRegisteredStoreSetupAsync();
        Task<StoreSetup> SearchStoreSetupByIdAsync(int Id);
        Task<int>GetIdAsync();
        Task StoreSetupUpdateAsync(StoreSetupDTO storeSetup, int id);
        Task DeleteStoreSetupAsync(int id);
    }
}