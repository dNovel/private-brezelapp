// <copyright file="BrezelMSSqlContext.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Db
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var now = DateTime.Now;

            this.ChangeTracker.DetectChanges();
            foreach (var item in this.ChangeTracker.Entries()
                                  .Where(i => i.State == EntityState.Added || i.State == EntityState.Modified)
                                  .Where(i => i.Entity as IEntityAutoDateFields != null))
            {
                if (item.State == EntityState.Added)
                {
                    (item.Entity as IEntityAutoDateFields).DateCreated = now;
                }

                (item.Entity as IEntityAutoDateFields).DateUpdated = now;
            }

            // Call the SaveChanges method on the context;
            return await base.SaveChangesAsync();
        }
    }
}