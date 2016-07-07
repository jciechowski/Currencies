using Newtonsoft.Json;

namespace Currency.Models
{
    public class Rate
    {
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("rates")]
        public Rates Currencies { get; set; }
    }

    public class Rates
    {
        private double _gbp;
        private double _chf;
        private double _usd;
        private double _eur;

        [JsonProperty("GBP")]
        public double Gbp
        {
            get { return _gbp; }
            set { _gbp = 1/value; }
        }

        [JsonProperty("CHF")]
        public double Chf
        {
            get { return _chf; }
            set { _chf = 1/value; }
        }

        [JsonProperty("USD")]
        public double Usd
        {
            get { return _usd; }
            set { _usd = 1/value; }
        }

        [JsonProperty("EUR")]
        public double Eur
        {
            get { return _eur; }
            set { _eur = 1/value; }
        }
    }
}
