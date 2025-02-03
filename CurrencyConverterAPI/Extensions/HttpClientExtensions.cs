using CurrencyConverterAPI.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace CurrencyConverterAPI.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T?> GetAsync<T>(this HttpClient httpClient, string url)
        {
			try
			{
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(content);
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException("The requested resource was not found.", ex);
            }
        
        }
    }
}
