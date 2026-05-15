using GeoCodeLambdaApp.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace GeoCodeLambdaApp.Percistance.Services;
public class GoogleGeocodeService : IGeoCodeService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public GoogleGeocodeService(IConfiguration config)
    {
        _httpClient = new HttpClient();
        _apiKey = config["GOOGLE_GEOCODE_API_KEY"];
    }

    public async Task<string> GetGeocodeAsync(string address)
    {
        var encodedAddress = Uri.EscapeDataString(address);

        var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={encodedAddress}&key={_apiKey}";

        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}

