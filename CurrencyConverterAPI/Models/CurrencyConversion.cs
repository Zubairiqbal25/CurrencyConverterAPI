namespace CurrencyConverterAPI.Models
{
    public class CurrencyConversion
    {
        public string? SourceCurrency { get; set; }
        public string? TargetCurrency { get; set; }
        public decimal Amount { get; set; }
    }
}
