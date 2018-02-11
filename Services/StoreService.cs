using System.Collections.Generic;
using System.Threading.Tasks;
using Brezelapp.Models;
using Brezelapp.Services.Contracts;
using Brezelapp.Db;

namespace Brezelapp.Services
{
    internal class StoreService : IStoreService
    {
        private BrezelMSSqlContext dbContext;

        public StoreService(BrezelMSSqlContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Store> CreateStore(Store store)
        {
            await this.dbContext.Stores.AddAsync(store);
            await this.dbContext.SaveChangesAsync();

            return store;
        }

        public async Task<bool> DeleteStoreById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Store> GetStoreById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Store>> GetStores(int offset, int limit)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Store>> GetStoresByLocation(double lat, double lon, int range)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Store>> GetStoresByRating(int minRating, int maxRating)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> UpdateStore(int id, Store store)
        {
            throw new System.NotImplementedException();
        }
    }
}