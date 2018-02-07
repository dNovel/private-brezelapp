using System.Threading.Tasks;
using Brezelapp.Models;
using Brezelapp.Services.Contracts;
using Brezelapp.Db;

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
            throw new System.NotImplementedException();
        }

        public async Task<bool> DeleteBrezelById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Brezel> GetBrezelById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> UpdateBrezel(int id, Brezel brezel)
        {
            throw new System.NotImplementedException();
        }
    }
}