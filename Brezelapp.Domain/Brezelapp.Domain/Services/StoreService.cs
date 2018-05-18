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
    using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public async Task<bool> DeleteStoreById(Guid storeId)
        {
            try
            {
                this.dbContext.Stores.Remove(await this.dbContext.Stores.FirstOrDefaultAsync(s => s.EntityId.Equals(storeId)));
                await this.dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Store> GetStoreById(Guid id)
        {
            try
            {
                Store store = await this.dbContext.Stores.Include(o => o.Address).Include(o => o.Address.GeoLoc).FirstOrDefaultAsync(s => s.EntityId == id);
                return store;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Store>> GetStores(int offset, int limit)
        {
            List<Store> stores = await this.dbContext.Stores.Include(o => o.Address).OrderBy(x => x.Id).Skip(offset).Take(limit).ToListAsync();
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

        public async Task<Store> UpdateStore(Guid storeId, Store changedStore)
        {
            try
            {
                Store tmpStore = await this.dbContext.Stores.FirstOrDefaultAsync(s => s.EntityId.Equals(storeId));

                if (tmpStore != null)
                {
                    tmpStore.Name = changedStore.Name;
                    tmpStore.Description = changedStore.Description;
                    tmpStore.Address = changedStore.Address ?? tmpStore.Address;

                    EntityEntry<Store> updatedStore = this.dbContext.Stores.Update(tmpStore);
                    await this.dbContext.SaveChangesAsync();
                    return updatedStore.Entity;
                }
                else
                {
                    // Store not found
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}