﻿using System.Collections.Generic;
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
/*
{
    "base":"EUR","date":"2016-07-04",
    "rates":
    {
        "AUD":1.4792,"BGN":1.9558,"BRL":3.6131,"CAD":1.4328,
        "CHF":1.0839,"CNY":7.4229,"CZK":27.095,"DKK":7.441,
        "GBP":0.83905,"HKD":8.6418,"HRK":7.518,"HUF":316.93,
        "IDR":14586.69,"ILS":4.2916,"INR":74.9065,"JPY":114.29,"KRW":1278.83,
        "MXN":20.4241,"MYR":4.4459,"NOK":9.2538,"NZD":1.5452,
        "PHP":52.176,"PLN":4.4304,"RON":4.5133,"RUB":71.0115,
        "SEK":9.391,"SGD":1.4989,"THB":39.028,"TRY":3.2284,"USD":1.1138,"ZAR":16.1416
    }
}

    */
