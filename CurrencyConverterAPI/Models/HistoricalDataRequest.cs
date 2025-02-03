namespace CurrencyConverterAPI.Models
{
    public class HistoricalDataRequest
    {
        public string? BaseCurrency { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int Page { get; set; } = 1;
        public int PerPage { get; set; } = 10;
    }
}
