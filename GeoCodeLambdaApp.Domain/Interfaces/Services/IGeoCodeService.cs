namespace GeoCodeLambdaApp.Domain.Interfaces.Services;

public interface IGeoCodeService
{
    Task<string> GetGeocodeAsync(string address);
}

