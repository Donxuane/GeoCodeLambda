using System.Net;

namespace GeoCodeLambdaApp.Shared.Models;

public class Result<TResult>
{
    public TResult Data { get; set; }
    public HttpStatusCode Status { get; set; }
    public string? Message { get; set; }

    public static Result<TResult> Ok(TResult data)
        => new Result<TResult> { Data = data, Status = HttpStatusCode.OK };

    public static Result<TResult> Fail(string message, HttpStatusCode status = HttpStatusCode.BadRequest)
        => new Result<TResult> { Data = default!, Message = message, Status = status };
}