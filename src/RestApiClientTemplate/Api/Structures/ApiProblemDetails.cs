namespace RestApiClientTemplate.Api.Structures;

internal static class ApiProblemDetails
{

    public static readonly Refit.ProblemDetails BadRequestNameRequiredProblemDetails = new()
    {
        Status = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest,
        Type = "badrequest_required_name"
    };

    public static readonly Refit.ProblemDetails BadRequestNameLongProblemDetails = new()
    {
        Status = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest,
        Type = "badrequest_long_name"
    };
}
