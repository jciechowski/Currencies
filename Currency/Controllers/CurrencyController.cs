using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Currency.Models;

namespace Currency.Controllers
{
    public class CurrencyController : ApiController
    {
        [HttpGet]
        public Rate Get()
        {
            var result = new Rate();
            using (var httpClient = new HttpClient())
            {
                var task = httpClient.GetStringAsync("http://api.fixer.io/latest?base=PLN").ContinueWith(taskResponse =>
                {
                    var response = taskResponse.Result;
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<Rate>(response);
                });
                task.Wait();
            }
            return result;
        }

        [HttpGet]
        [Route("api/currency/{currency}")]
        public Rate Get(string currency)
        {
            var result = new Rate();
            using (var httpClient = new HttpClient())
            {
                var task = httpClient.GetStringAsync("http://api.fixer.io/latest?base=PLN?symbols=" + currency).ContinueWith(taskResponse =>
                {
                    var response = taskResponse.Result;
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<Rate>(response);
                });
                task.Wait();
            }
            return result;
        }

        [HttpGet]
        [Route("api/currency/date/{date}/{days}")]
        public IEnumerable<Rate> Get(DateTime date, int days)
        {
            var startDate = date.AddDays(-days);
            var result = new List<Rate>();
            using (var httpClient = new HttpClient())
            {
                while (startDate <= date)
                {
                    var task = httpClient.GetStringAsync("http://api.fixer.io/" + startDate.ToString("yyyy-MM-dd")+ "?base=PLN").ContinueWith(taskResponse =>
                    {
                        var response = taskResponse.Result;
                        result.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<Rate>(response));
                    });
                    task.Wait();
                    startDate = startDate.AddDays(1);
                }
            }
            return result;
        }
    }
}