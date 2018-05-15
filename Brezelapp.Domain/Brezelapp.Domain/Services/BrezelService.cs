// <copyright file="BrezelService.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Brezelapp.Db;
    using Brezelapp.Models;
    using Brezelapp.Services.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class BrezelService : IBrezelService
    {
        private BrezelMSSqlContext dbContext;

        public BrezelService(BrezelMSSqlContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Brezel> CreateBrezel(Brezel brezel)
        {
            try
            {
                this.dbContext.Brezels.Add(brezel);
                var touched = await this.dbContext.SaveChangesAsync();

                if (touched < 0)
                {
                    return null;
                }

                return brezel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Brezel> GetBrezelById(Guid id)
        {
            Brezel brezel = await this.dbContext.Brezels.FirstOrDefaultAsync(x => x.EntityId == id);
            return brezel;
        }

        async Task<int> IBrezelService.UpdateBrezel(int id, Brezel brezel)
        {
            try
            {
                brezel.Id = id;
                this.dbContext.Brezels.Update(brezel);

                return await this.dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<bool> DeleteBrezelById(int id)
        {
            try
            {
                Brezel brezel = new Brezel()
                {
                    Id = id,
                };

                this.dbContext.Brezels.Remove(brezel);
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
    }
}