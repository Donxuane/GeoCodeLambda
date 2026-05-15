using GeoCodeLambdaApp.Domain.Interfaces.Services;
using GeoCodeLambdaApp.Domain.Models;
using GeoCodeLambdaApp.Shared.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GeoCodeLambdaApp.Controllers;

[ApiController]
[Route("[controller]")]
public class GeoCodeController(ISender sender) : ControllerBase
{
    [HttpGet("getGeoCode")]
    public async Task<ActionResult<Result<GeoCode>>> GetGeoCode([FromQuery] string address)
    {
        var result = await sender.Send(new Application.Features.GeoCode.GeoCodeQuery(address));
        return result;
    }
}
