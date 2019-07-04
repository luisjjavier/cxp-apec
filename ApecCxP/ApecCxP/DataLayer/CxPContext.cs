using ApecCxP.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApecCxP.DataLayer
{
    public sealed class CxPContext : DbContext
    {
        public CxPContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyConfigurations(modelBuilder);
        }

        internal DbSet<PaymentConcept> PaymentConcepts { get; set; }

        internal DbSet<Provider> Providers { get; set; }

        internal DbSet<DocumentEntry> DocumentEntries { get; set; }

        internal DbSet<Account> Accounts { get; set; }

        private static void ApplyConfigurations(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(CxPContext)));
    }
}
