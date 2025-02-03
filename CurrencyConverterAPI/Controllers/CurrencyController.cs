using CurrencyConverterAPI.Common;
using CurrencyConverterAPI.Common.Exceptions;
using CurrencyConverterAPI.Models;
using CurrencyConverterAPI.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController(ICurrencyService currencyService) : ControllerBase
    {
        private string[] excludedCurrencies = new[] { "TRY", "PLN", "THB", "MXN", "AED", "PKR" };
        [HttpGet("rates/{baseCurrency}")]
        public async Task<IActionResult> GetLatestRates(string baseCurrency)
        {
            try
            {
                if (excludedCurrencies.Contains(baseCurrency, StringComparer.OrdinalIgnoreCase))
                {
                    return BadRequest("Conversion for TRY, PLN, THB, AED, PKR, and MXN is not supported.");
                }
                var result = await currencyService.GetLatestRatesByCurrencyAsync(baseCurrency);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if(ex is NotFoundException)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return BadRequest(new ApiResultBadRequest(ex.Message));
                }
            }
        }

        [HttpPost("convert")]
        public async Task<IActionResult> ConvertCurrency([FromBody] CurrencyConversion request)
        {
            try
            {
                if (excludedCurrencies.Contains(request.TargetCurrency, StringComparer.OrdinalIgnoreCase) ||
                    excludedCurrencies.Contains(request.SourceCurrency, StringComparer.OrdinalIgnoreCase))
                {
                    return BadRequest("Conversion for TRY, PLN, THB, AED, PKR, and MXN is not supported.");
                }

                var result = await currencyService.ConvertCurrencyAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return BadRequest(new ApiResultBadRequest(ex.Message));
                }
            }
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistoricalRates([FromQuery] HistoricalDataRequest request)
        {
            try
            {
                var result = await currencyService.GetHistoricalRatesAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                {
                    return NotFound(ex.Message);
                }
                else
                {
                    return BadRequest(new ApiResultBadRequest(ex.Message));
                }
            }
        }
    }
}
