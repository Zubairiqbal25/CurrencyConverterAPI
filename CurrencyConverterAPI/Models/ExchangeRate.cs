using System.Text.Json.Serialization;

namespace CurrencyConverterAPI.Models
{
    public class ExchangeRate
    {
        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; } // Should be int

        [JsonPropertyName("base")]
        public string BaseCurrency { get; set; } = string.Empty; // Renamed for clarity

        [JsonPropertyName("date")]
        public string Date { get; set; } = string.Empty;

        [JsonPropertyName("rates")]
        public Dictionary<string, decimal> Rates { get; set; } = new();
    }
}
