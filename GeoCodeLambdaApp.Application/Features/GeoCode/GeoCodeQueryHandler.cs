using Amazon.Runtime.Internal.Util;
using GeoCodeLambdaApp.Domain.Interfaces.Services;
using GeoCodeLambdaApp.Shared.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace GeoCodeLambdaApp.Application.Features.GeoCode;

public class GeoCodeQueryHandler(ILogger<GeoCodeQueryHandler> logger,
      IGeoCodeService _geocodeService,
 IDynamoCacheService _cacheService) : IRequestHandler<GeoCodeQuery, Result<Domain.Models.GeoCode>>
{
    private JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    };
    public async Task<Result<Domain.Models.GeoCode>> Handle(GeoCodeQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Address))
            return Result<Domain.Models.GeoCode>.Fail("Address cannot be empty");

        logger.LogInformation("Received geocode request for: {Address}", request.Address);
        var cached = await _cacheService.GetCachedGeocodeAsync(request.Address);

        if (cached != null)
        {

            logger.LogInformation("Returning cached response");
            var returnData = JsonSerializer.Deserialize<Domain.Models.GeoCode>(cached, _jsonOptions);
            return Result<Domain.Models.GeoCode>.Ok(returnData);
        }

        logger.LogInformation("Cache miss. Calling Google API.");

        var googleResponse = await _geocodeService.GetGeocodeAsync(request.Address);
        await _cacheService.SaveToCacheAsync(request.Address, googleResponse);

        return Result<Domain.Models.GeoCode>.Ok(JsonSerializer.Deserialize<Domain.Models.GeoCode>(googleResponse,_jsonOptions));
    }
}
