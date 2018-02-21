using System.Threading.Tasks;
using Brezelapp.Models;
using Brezelapp.Services.Contracts;
using Brezelapp.Db;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Brezelapp.Services
{
    internal class BrezelService : IBrezelService
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
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Brezel> GetBrezelById(int id)
        {
            Brezel brezel = await this.dbContext.Brezels.FirstOrDefaultAsync(x => x.Id == id);
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
            catch (Exception e)
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
            catch (Exception e)
            {
                // TODO: Do anything
                return false;
            }
        }

    }
}