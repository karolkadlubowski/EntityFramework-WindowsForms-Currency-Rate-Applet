using CryptoMoon.Domain;
using CryptoMoon.Services;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoMoon.Data
{
    public class DatabaseManager
    {
        private readonly IDatabase database = new Database();

        public async Task InitDatabase()
        {
            if (database.CurrencyRepository.GetAll().Any())
                return;
            var currencies = CurrencyConverterService.GetCurrencyTags().Select(c => Currency.Create(c));
            database.CurrencyRepository.AddRange(currencies);
            await database.Complete();
        }
    }
}
