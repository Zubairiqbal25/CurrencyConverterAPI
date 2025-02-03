using CurrencyConverterAPI.Clients;
using CurrencyConverterAPI.Services;

namespace CurrencyConverterAPI.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
    {
        //Repositories
        services.AddTransient<ICurrencyService, CurrencyService>();
        var baseUrl = configuration["FrankfurterClient:BaseUrl"];
        services.AddHttpClient<IFrankfurterClient, FrankfurterClient>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });
    }
}
