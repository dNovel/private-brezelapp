// <copyright file="BrezelMSSqlContext.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Db
{
    using System;
    using System.Linq;
    using Brezelapp.Contracts;
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

        public override int SaveChanges()
        {
            var now = DateTime.Now;

            this.ChangeTracker.DetectChanges();
            foreach (var item in this.ChangeTracker.Entries()
                                  .Where(i => i.State == EntityState.Added || i.State == EntityState.Modified)
                                  .Where(i => i as IEntityAutoDateFields != null))
            {
                if (item.State == EntityState.Added)
                {
                    (item as IEntityAutoDateFields).DateCreated = now;
                }

                (item as IEntityAutoDateFields).DateUpdated = now;
            }

            // Call the SaveChanges method on the context;
            return base.SaveChanges();
        }
    }
}