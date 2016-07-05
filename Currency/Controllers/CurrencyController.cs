using System.Net.Http;
using System.Web.Http;
using Currency.Models;

namespace Currency.Controllers
{
    public class CurrencyController : ApiController
    {
        // GET api/<controller>
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

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}