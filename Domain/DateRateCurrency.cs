using System;

namespace CryptoMoon.Domain
{
    public class DateRateCurrency
    {
        public DateRateCurrency()
        {
        }

        public DateRateCurrency(DateTime measureDate, float rate, int currencyId)
        {
            MeasureDate = measureDate;
            Rate = rate;
            CurrencyId = currencyId;
        }

        public int Id { get; set; }

        public DateTime MeasureDate { get; set; }

        public float Rate { get; set; }

        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
