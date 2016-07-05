using System.Collections.Generic;
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
        [JsonProperty("GBP")]
        public double Gbp{ get; set; }
        [JsonProperty("CHF")]
        public double Chf { get; set; }
        [JsonProperty("USD")]
        public double Usd { get; set; }
    }
}
