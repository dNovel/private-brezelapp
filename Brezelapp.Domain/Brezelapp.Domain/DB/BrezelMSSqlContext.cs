// <copyright file="BrezelMSSqlContext.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Db
{
    using Brezelapp.Models;
    using Microsoft.EntityFrameworkCore;

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