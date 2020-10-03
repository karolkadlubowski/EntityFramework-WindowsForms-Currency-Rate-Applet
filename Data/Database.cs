using CryptoMoon.Domain;
using System.Threading.Tasks;

namespace CryptoMoon.Data
{
    public class Database : IDatabase
    {
        private readonly DataContext context;
        public Database(DataContext context=null)
        {
            this.context = context ?? new DataContext();
        }

        private IRepository<Currency> currencyRepository;

        public IRepository<Currency> CurrencyRepository
        {
            get => currencyRepository ?? new Repository<Currency>(context);
        }

        private IRepository<DateRateCurrency> dateRateCurrencyRepository;

        public IRepository<DateRateCurrency> DateRateCurrencyRepository
        {
            get => dateRateCurrencyRepository ?? new Repository<DateRateCurrency>(context);
        }
        public async Task<bool> Complete()
            => await context.SaveChangesAsync() > 0;

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
