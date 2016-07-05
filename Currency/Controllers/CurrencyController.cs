using System.Net.Http;
using System.Web.Http;
using Currency.Models;

namespace Currency.Controllers
{
    public class CurrencyController : ApiController
    {
        public Rate Get()
        {
            var result = new Rate();
            using (var httpClient = new HttpClient())
            {
                var task = httpClient.GetStringAsync("http://api.fixer.io/latest").ContinueWith(taskResponse =>
                {
                    var response = taskResponse.Result;
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<Rate>(response);
                });
                task.Wait();
            }
            return result;
        }

        public double Get(string currency)
        {
            return 1.0;
        }
    }
}