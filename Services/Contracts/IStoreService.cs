using System.Collections.Generic;
using System.Threading.Tasks;
using Brezelapp.Models;

namespace Brezelapp.Services.Contracts
{
    internal interface IStoreService
    {
        Task<Store> CreateStore(Store store);

        Task<Store> GetStoreById(int id);

        Task<List<Store>> GetStores(int offset, int limit);

        Task<List<Store>> GetStoresByLocation(double lat, double lon, int range);

        Task<List<Store>> GetStoresByRating(int minRating, int maxRating);

        Task<int> UpdateStore(int id, Store store);

        Task<bool> DeleteStoreById(int id);
    }
}