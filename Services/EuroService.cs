using CryptoMoon.Data;
using CryptoMoon.Domain;
using CryptoMoon.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CryptoMoon.Services
{
    public class EuroService
    {
        private readonly IDatabase database = new Database();
        public CurrencyConverterService CSS { get; set; } = new CurrencyConverterService();

        public DateRateCurrency DateRateCurrency { get; set; } = new DateRateCurrency();

        public List<CurrencyRate> CurrencyRates { get; set; } = new List<CurrencyRate>();

        public EuroService(string from, float amount)
        {
            InitEuroService(from,amount);

        }

        private void InitEuroService(string from, float amount)
        {
            
            var dateRateCurrencies = (from=="eur") ? 
                database.DateRateCurrencyRepository.GetWhere(d => d.MeasureDate == DateTime.Today).ToList() : new List<DateRateCurrency>();

            if (dateRateCurrencies.Any())
            {
                foreach (DateRateCurrency dateRateCurrency in dateRateCurrencies)
                    CurrencyRates.Add(new CurrencyRate(dateRateCurrency.Currency.Name, dateRateCurrency.Rate));
                return;
            }
            
                var currencies = CurrencyConverterService.GetCurrencyTags();
                float rate;
                string currencyName;

                for (int i = 0; i < 33; i++)
                {
                    currencyName = currencies[i];
                    rate = CSS.GetExchangeRate(from, currencyName,amount);
                    CurrencyRates.Add(new CurrencyRate(currencyName, rate));
                    dateRateCurrencies.Add(new DateRateCurrency(DateTime.Today, rate, i + 1));
                }
                if(from=="eur"&&amount==1)
            { 
                database.DateRateCurrencyRepository.AddRange(dateRateCurrencies);
                database.Complete();
                }
            
        }

        /*public void MultiplyValue(DataGridView dataGridView, float x)
        {
            foreach(CurrencyRate currencyRate in CurrencyRates)
            {
                currencyRate.Rate = currencyRate.Rate * x;
            }
            dataGridView.DataSource = CurrencyRates;
            dataGridView.Update();
        }*/
    }
}
