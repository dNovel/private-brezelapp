// <copyright file="StoreService.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Brezelapp.Db;
    using Brezelapp.Models;
    using Brezelapp.Services.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class StoreService : IStoreService
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
            try
            {
                Store store = new Store()
                {
                    Id = id,
                };

                this.dbContext.Stores.Remove(store);
                await this.dbContext.SaveChangesAsync();

                // TODO: make this cleaner
                return true;
            }
            catch (Exception)
            {
                // TODO: Do anything
                return false;
            }
        }

        public async Task<Store> GetStoreById(int id)
        {
            try
            {
                Store store = await this.dbContext.Stores.FirstOrDefaultAsync(s => s.Id == id);
                return store;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Store>> GetStores(int offset, int limit)
        {
            List<Store> stores = await this.dbContext.Stores.OrderBy(x => x.Id).Skip(offset).Take(limit).ToListAsync();
            return stores;
        }

        public async Task<List<Store>> GetStoresByLocation(double lat, double lon, int range)
        {
            // TODO: Implement this
            throw new System.NotImplementedException();
        }

        public async Task<List<Store>> GetStoresByRating(int minRating, int maxRating)
        {
            List<Store> stores = await this.dbContext.Brezels.Include(brezel => brezel.Ratings.Aggregate(0, (a, b) => a + b.Value) <= maxRating && brezel.Ratings.Aggregate(0, (a, b) => a + b.Value) >= minRating).OrderBy(brezel => brezel.Id).Select(brezel => brezel.Store).ToListAsync();
            return stores;
        }

        public async Task<Store> UpdateStore(int id, Store store)
        {
            try
            {
                store.Id = id;
                this.dbContext.Stores.Update(store);
                await this.dbContext.SaveChangesAsync();
                return store;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}