using System.Threading.Tasks;
using Brezelapp.Models;

namespace Brezelapp.Services.Contracts
{
    public interface IBrezelService
    {
        Task<Brezel> CreateBrezel(Brezel brezel);

        Task<Brezel> GetBrezelById(int id);

        Task<int> UpdateBrezel(int id, Brezel brezel);

        Task<bool> DeleteBrezelById(int id);
    }
}