using GeoCodeLambdaApp.Shared.Models;
using MediatR;

namespace GeoCodeLambdaApp.Application.Features.GeoCode;

public record GeoCodeQuery(string Address): IRequest<Result<Domain.Models.GeoCode>>;
