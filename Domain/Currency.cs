using System.Collections.Generic;

namespace CryptoMoon.Domain
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DateRateCurrency> DateRateCurrencies { get; set; }

        public static Currency Create(string name)
            => new Currency { Name = name };
    }
}
