// <copyright file="IStoreService.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Brezelapp.Models;

    public interface IStoreService
    {
        Task<Store> CreateStore(Store store);

        Task<Store> GetStoreById(int id);

        Task<List<Store>> GetStores(int offset, int limit);

        Task<List<Store>> GetStoresByLocation(double lat, double lon, int range);

        Task<List<Store>> GetStoresByRating(int minRating, int maxRating);

        Task<Store> UpdateStore(int id, Store store);

        Task<bool> DeleteStoreById(int id);
    }
}