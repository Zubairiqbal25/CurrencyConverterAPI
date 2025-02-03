using CurrencyConverterAPI.Models;

namespace CurrencyConverterAPI.Services
{
    public interface ICurrencyService
    {
        Task<decimal?> ConvertCurrencyAsync(CurrencyConversion request);
        Task<HistoryExchangeRate?> GetHistoricalRatesAsync(HistoricalDataRequest request);
        Task<ExchangeRate?> GetLatestRatesAsync();
        Task<ExchangeRate?> GetLatestRatesByCurrencyAsync(string baseCurrency);
    }
}