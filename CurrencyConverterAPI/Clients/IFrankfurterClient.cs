using CurrencyConverterAPI.Models;

namespace CurrencyConverterAPI.Clients
{
    public interface IFrankfurterClient
    {
        Task<HistoryExchangeRate?> GetHistoricalRatesAsync(HistoricalDataRequest request);
        Task<ExchangeRate?> GetLatestRatesByCurrencyAsync(string baseCurrency);
        Task<ExchangeRate?> GetLatestRatesAsync();
    }
}