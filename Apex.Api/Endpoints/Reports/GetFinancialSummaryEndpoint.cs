using System.Security.Claims;
using Apex.Api.Common.Api;
using Apex.Core.Handlers;
using Apex.Core.Models.Reports;
using Apex.Core.Requests.Reports;
using Apex.Core.Responses;

namespace Apex.Api.Endpoints.Reports;

public class GetFinancialSummaryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/summary", HandleAsync)
            .Produces<Response<FinancialSummary?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IReportHandler handler)
    {
        var request = new GetFinancialSummaryRequest
        {
            UserId = user.Identity?.Name ?? string.Empty
        };
        var result = await handler.GetFinancialSummaryReportAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}