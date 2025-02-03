using CurrencyConverterAPI.Clients;
using CurrencyConverterAPI.Common.Exceptions;
using CurrencyConverterAPI.Models;

namespace CurrencyConverterAPI.Services
{
    public class CurrencyService(IFrankfurterClient frankfurterClient) : ICurrencyService
    {

        public async Task<ExchangeRate?> GetLatestRatesAsync()
        {
            return await frankfurterClient.GetLatestRatesAsync();
        }

        public async Task<ExchangeRate?> GetLatestRatesByCurrencyAsync(string baseCurrency)
        {
            ArgumentException.ThrowIfNullOrEmpty(baseCurrency);
            return await frankfurterClient.GetLatestRatesByCurrencyAsync(baseCurrency);
        }

        public async Task<decimal?> ConvertCurrencyAsync(CurrencyConversion request)
        {
            ArgumentException.ThrowIfNullOrEmpty(request.SourceCurrency);
            ArgumentException.ThrowIfNullOrEmpty(request.TargetCurrency);
            var rates = await frankfurterClient.GetLatestRatesByCurrencyAsync(request.SourceCurrency);
            NotFoundException.ThrowIfNull(rates);
            return request.Amount * rates.Rates[request.TargetCurrency];
        }

        public async Task<HistoryExchangeRate?> GetHistoricalRatesAsync(HistoricalDataRequest request)
        {
            return await frankfurterClient.GetHistoricalRatesAsync(request);
        }
    }
}
