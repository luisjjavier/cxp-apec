using ApecAxP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApecAxP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        internal DbSet<PaymentConcept> PaymentConcepts { get; set; }

        internal DbSet<Provider> Providers { get; set; }

        internal DbSet<DocumentEntry> DocumentEntries { get; set; }
    }
}
