using System.Text.Json.Serialization;

namespace CurrencyConverterAPI.Models
{
    public class HistoryExchangeRate
    {
        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }

        [JsonPropertyName("base")]
        public string BaseCurrency { get; set; } = string.Empty;

        [JsonPropertyName("start_date")]
        public string StartDate { get; set; } = string.Empty;

        [JsonPropertyName("end_date")]
        public string EndDate { get; set; } = string.Empty;

        [JsonPropertyName("rates")]
        public Dictionary<string, Dictionary<string, decimal>> Rates { get; set; } = new();
    }
}
