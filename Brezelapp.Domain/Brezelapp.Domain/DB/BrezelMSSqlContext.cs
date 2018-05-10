// <copyright file="StoreRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Brezelapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Brezelapp.Db
{
    public class BrezelMSSqlContext : DbContext
    {
        public BrezelMSSqlContext(DbContextOptions<BrezelMSSqlContext> options)
        : base(options)
        {

        }

        protected BrezelMSSqlContext()
        : base()
        {

        }

        public DbSet<Store> Stores { get; set; }
        public DbSet<Brezel> Brezels { get; set; }
    }
}