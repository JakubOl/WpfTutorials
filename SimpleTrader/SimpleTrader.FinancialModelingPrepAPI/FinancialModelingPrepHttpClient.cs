using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClient : HttpClient
    {
        private readonly string _apiKey;

        public FinancialModelingPrepHttpClient()
        {
            this.BaseAddress = new Uri("https://financialmodelingprep.com//api/v3/");
            _apiKey = "3532baa7edd9e854c317707d454f3aaa";
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await GetAsync($"{uri}?apikey={_apiKey}");
            string jsonResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(jsonResponse);
            return result;
        }

    }
}
