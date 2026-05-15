namespace GeoCodeLambdaApp.Domain.Interfaces.Services;

public interface IDynamoCacheService
{
    Task<string?> GetCachedGeocodeAsync(string address);
    Task SaveToCacheAsync(string address, string responseJson);
}
