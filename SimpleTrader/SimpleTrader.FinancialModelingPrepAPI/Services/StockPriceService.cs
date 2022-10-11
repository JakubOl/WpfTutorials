using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        public async Task<double> GetPrice(string symbol)
        {
            using (var client = new FinancialModelingPrepHttpClientEnum())
            {
                string uri = "quote-short/" + symbol;

                var stockPriceResult = await client.GetAsync<StockPriceResult>(uri);

                if(stockPriceResult.First().Price == 0)
                {
                    throw new InvalidSymbolException(symbol);
                }

                return stockPriceResult.First().Price;
            }
        }
    }
}
