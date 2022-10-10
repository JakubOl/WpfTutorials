using Newtonsoft.Json;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
            {
                string apiKey = "3532baa7edd9e854c317707d454f3aaa";
                string uri = "quote-short/" + symbol;

                var stockPriceResult = await client.GetAsync<StockPriceResult>(uri);

                if(stockPriceResult.Price == 0)
                {
                    throw new InvalidSymbolException(symbol);
                }

                return stockPriceResult.Price;
            }
        }
    }
}
