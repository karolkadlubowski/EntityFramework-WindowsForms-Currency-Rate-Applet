namespace CryptoMoon.Models
{
    public class CurrencyRate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Rate { get; set; }

        public CurrencyRate()
        {

        }

        public CurrencyRate(string name, float rate)
        {
            this.Name = name;
            this.Rate = rate;
        }
        
    }
}
