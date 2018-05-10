// <copyright file="StoreRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Brezelapp.Models;
using System.Threading.Tasks;

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