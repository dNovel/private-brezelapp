// <copyright file="IBrezelService.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Services.Contracts
{
    using System;
    using System.Threading.Tasks;
    using Brezelapp.Models;

    public interface IBrezelService
    {
        Task<Brezel> CreateBrezel(Brezel brezel);

        Task<Brezel> GetBrezelById(Guid id);

        Task<int> UpdateBrezel(int id, Brezel brezel);

        Task<bool> DeleteBrezelById(int id);
    }
}