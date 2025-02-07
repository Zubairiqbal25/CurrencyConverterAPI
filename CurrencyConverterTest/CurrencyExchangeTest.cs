using CurrencyConverterAPI.Clients;
using CurrencyConverterAPI.Models;
using CurrencyConverterAPI.Services;
using Moq;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverterTest
{
    public class CurrencyExchangeTest
    {
        private readonly Mock<FrankfurterClient> _mockClient;
        private readonly CurrencyService _service;
        public CurrencyExchangeTest()
        {
            _mockClient = new Mock<FrankfurterClient>();
            _service = new CurrencyService(_mockClient.Object);
        }
        [Fact]
        public async Task GetLatestRatesAsync_ReturnsExchangeRate()
        {
            // Arrange
            var expectedRates = new ExchangeRate
            {
                BaseCurrency = "USD",
                Rates = new Dictionary<string, decimal> { { "EUR", 0.85m } }
            };
            _mockClient.Setup(client => client.GetLatestRatesByCurrencyAsync("USD"))
                .ReturnsAsync(expectedRates);
            // Act
            var result = await _service.GetLatestRatesByCurrencyAsync("USD");
            // Assert
            result.Should().BeEquivalentTo(expectedRates);
        }
        [Fact]
        public async Task ConvertCurrencyAsync_ReturnsConvertedAmount()
        {
            // Arrange
            var request = new CurrencyConversion
            {
                SourceCurrency = "USD",
                TargetCurrency = "EUR",
                Amount = 100
            };
            var rates = new ExchangeRate
            {
                BaseCurrency = "USD",
                Rates = new Dictionary<string, decimal> { { "EUR", 0.85m } }
            };
            _mockClient.Setup(client => client.GetLatestRatesByCurrencyAsync("USD"))
                .ReturnsAsync(rates);
            // Act
            var result = await _service.ConvertCurrencyAsync(request);
            // Assert
            result.Should().Be(85m);
        }
        [Fact]
        public async Task GetHistoricalRatesAsync_ReturnsExchangeRate()
        {
            // Arrange
            var request = new HistoricalDataRequest
            {
                BaseCurrency = "USD",
                StartDate = "2023-01-01",
                EndDate = "2023-01-31",
                Page = 1,
                PerPage = 10
            };
            var Rates = new Dictionary<string, Dictionary<string, decimal>>
           {
               { "2023-01-01", new Dictionary<string, decimal> { { "EUR", 0.85m } } }
           };
            var expectedRates = new HistoryExchangeRate
            {
                BaseCurrency = "USD",
                Amount = 1,
                StartDate = "2023-01-01",
                EndDate = "2023-01-31",
                Rates = Rates
            };
            _mockClient.Setup(client => client.GetHistoricalRatesAsync(request))
                 .ReturnsAsync(expectedRates);
            // Act
            var result = await _service.GetHistoricalRatesAsync(request);
            // Assert
            result.Should().BeEquivalentTo(expectedRates);
        }
    }
}
