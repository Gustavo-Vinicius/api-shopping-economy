using Dapper;
using Microsoft.EntityFrameworkCore;
using shopping_economy.Core.DTOs;
using shopping_economy.Core.Entities;
using shopping_economy.Core.Interface;

namespace shopping_economy.Infrastructure.Persistence.Repository
{
    public class StoreSetupRepository : IStoreSetupRepository
    {

          private readonly DataBaseContext _context;

        public StoreSetupRepository(DataBaseContext context)
        {
            _context = context;
        }
        public async Task InsertStoreSetupAsync(StoreSetup storeSetup)
        {
            _context.Add(storeSetup);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StoreSetupDTO>> SearchListOfRegisteredStoreSetupAsync()
        {
            var query = "SELECT * FROM store_setup";

            return await _context.Database.GetDbConnection().QueryAsync<StoreSetupDTO>(query);
        }

        public async Task<int> GetIdAsync()
        {
           var id = await _context.Products.Select(x => x.Id).FirstOrDefaultAsync();

            return id;
        }

        public Task<StoreSetup> SearchStoreSetupByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task StoreSetupUpdateAsync(StoreSetupDTO storeSetup, int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteStoreSetupAsync(int id)
        {
             var selectStoreSetup = await _context.StoreSetups.SingleOrDefaultAsync(x => x.Id == id);

            _context.Remove(selectStoreSetup);

            await _context.SaveChangesAsync();
        }
    }
}