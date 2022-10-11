using Newtonsoft.Json;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClientEnum : HttpClient
    {
        private readonly string _apiKey;

        public FinancialModelingPrepHttpClientEnum()
        {
            this.BaseAddress = new Uri("https://financialmodelingprep.com//api/v3/");
            _apiKey = "3532baa7edd9e854c317707d454f3aaa";
        }

        public async Task<IEnumerable<T>> GetAsync<T>(string uri)
        {
            var response = await GetAsync($"{uri}?apikey={_apiKey}");
            string jsonResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<IEnumerable<T>>(jsonResponse);
            return result;
        }

    }
}
