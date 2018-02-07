using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Brezelapp.Models;

namespace Brezelapp.Db
{
    internal class BrezelMSSqlContext : DbContext
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