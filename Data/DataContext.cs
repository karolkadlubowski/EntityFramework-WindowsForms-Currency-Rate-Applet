using CryptoMoon.Domain;
using CryptoMoon.Services;
using System.Data.Entity;

namespace CryptoMoon.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DefaultConnection")
        {
            
        }

        public virtual DbSet<Currency> Currencies { get; set; }

        public virtual DbSet<DateRateCurrency> DateRateCurrencies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .HasMany(c => c.DateRateCurrencies)
                .WithRequired(d => d.Currency)
                .HasForeignKey(d => d.CurrencyId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
