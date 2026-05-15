using Amazon.DynamoDBv2;
using GeoCodeLambdaApp.Domain.Interfaces.Services;
using GeoCodeLambdaApp.Percistance.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GeoCodeLambdaApp.Percistance.Configuration;

public static class Configuration
{
    public static IServiceCollection ConfigureCloaudServices(this IServiceCollection services)
    {
        services.AddAWSService<IAmazonDynamoDB>();

        services.AddScoped<IGeoCodeService, GoogleGeocodeService>();
        services.AddScoped<IDynamoCacheService, DynamoCacheService>();
        return services;
    }
}
