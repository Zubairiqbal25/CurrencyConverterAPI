using CurrencyConverterAPI.Extensions;
using CurrencyConverterAPI.Models;
using System.Text.Json;

namespace CurrencyConverterAPI.Clients
{
    public class FrankfurterClient(HttpClient _httpClient) : IFrankfurterClient
    {
        public async Task<ExchangeRate?> GetLatestRatesAsync()
        {
            var result = await _httpClient.GetAsync<ExchangeRate>($"latest");
            return result;
        }

        public async Task<ExchangeRate?> GetLatestRatesByCurrencyAsync(string baseCurrency)
        {
            var result = await _httpClient.GetAsync<ExchangeRate>($"latest?from={baseCurrency}");
            return result;
        }

        public async Task<HistoryExchangeRate?> GetHistoricalRatesAsync(HistoricalDataRequest request)
        {
            var url = $"{request.StartDate}..{request.EndDate}?from={request.BaseCurrency}&page={request.Page}&per_page={request.PerPage}";
            var temp =  await _httpClient.GetAsync<HistoryExchangeRate>(url);
            return temp;
        }
    }
}
