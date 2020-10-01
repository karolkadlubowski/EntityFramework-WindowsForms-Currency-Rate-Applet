using CryptoMoon.Domain;
using System;
using System.Threading.Tasks;

namespace CryptoMoon.Data
{
    public interface IDatabase : IDisposable
    {
        IRepository<Currency> CurrencyRepository { get; }

        IRepository<DateRateCurrency> DateRateCurrencyRepository { get; }

        Task<bool> Complete();
    }
}
