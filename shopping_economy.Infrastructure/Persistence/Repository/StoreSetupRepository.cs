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

        public Task<IEnumerable<StoreSetupDTO>> SearchListOfRegisteredStoreSetupAsync()
        {
            throw new NotImplementedException();
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

        public Task DeleteStoreSetupAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}