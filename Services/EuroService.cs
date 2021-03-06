﻿using CryptoMoon.Data;
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

        public List<CurrencyRate> EuroCurrencyRates { get; set; } = new List<CurrencyRate>();

        public List<CurrencyRate> DataGriedCurrentCurrencyRates { get; set; } = new List<CurrencyRate>();

        public int CurrentDataGriedCurrencyIndex { get; set; }

        public float CurrentDataGriedAmount { get; set; }

        public EuroService()
        {
            InitEuroService();

        }

        private void InitEuroService()
        {

            var dateRateCurrencies = database.DateRateCurrencyRepository.GetWhere(d => d.MeasureDate == DateTime.Today).ToList();

            if (dateRateCurrencies.Any())
            {
                foreach (DateRateCurrency dateRateCurrency in dateRateCurrencies)
                    EuroCurrencyRates.Add(new CurrencyRate(dateRateCurrency.Currency.Name, dateRateCurrency.Rate));
            }
            else
            {

                var currencies = CurrencyConverterService.GetCurrencyTags();
                float rate;
                string currencyName;

                for (int i = 0; i < 33; i++)
                {
                    currencyName = currencies[i];
                    rate = CSS.GetExchangeRate("eur", currencyName);
                    EuroCurrencyRates.Add(new CurrencyRate(currencyName, rate));
                    dateRateCurrencies.Add(new DateRateCurrency(DateTime.Today, rate, i + 1));
                }
                database.DateRateCurrencyRepository.AddRange(dateRateCurrencies);
                database.Complete();
            }
            

        }

        private float calculateRate(string currency)
        => EuroCurrencyRates.Find(cr => cr.Name == currency).Rate;

        public float GetExchangeRateFromDatabase(string from, string to, float amount = 1)
        {
            if (to == null)
                return 0;

            // Convert Euro to Euro
            if (from.ToLower() == to.ToLower() )
                return amount;
            
            try
            {
                // First Get the exchange rate of both currencies in euro
                float fromRate= EuroCurrencyRates.Find(cr => cr.Name == from).Rate;
                float toRate=EuroCurrencyRates.Find(cr => cr.Name == to).Rate;

                // Convert Between Euro to Other Currency
                if (from.ToLower() == "eur")
                {
                    return (amount * toRate);
                }
                else if (to.ToLower() == "eur")
                {
                    return (amount / fromRate);
                }
                else
                {
                    // Calculate non EURO exchange rates From A to B
                    return (amount * toRate) / fromRate;
                }
            }
            catch { return 0; }
        }

        public List<CurrencyRate> GetCurrencyRates(string fromCurrency, float amount)
        {
            List<CurrencyRate> currencyRates = new List<CurrencyRate>();
            float fromRate = EuroCurrencyRates.Find(cr => cr.Name == fromCurrency).Rate;
            if (fromRate == 0)
                return null;

            string toCurrency;
            float toRate;
            for(int i=0;i<33;i++)
            {
                toCurrency = EuroCurrencyRates[i].Name;
                toRate= EuroCurrencyRates.Find(cr => cr.Name == toCurrency).Rate;                
                currencyRates.Add(new CurrencyRate(toCurrency, toRate/fromRate*amount));
            }
            return currencyRates;
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
