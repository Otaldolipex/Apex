using System.Security.Claims;
using Apex.Api.Common.Api;
using Apex.Core.Handlers;
using Apex.Core.Models.Reports;
using Apex.Core.Requests.Reports;
using Apex.Core.Responses;

namespace Apex.Api.Endpoints.Reports;

public class GetIncomesByCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/incomes", HandleAsync)
            .Produces<Response<List<IncomesByCategory>?>>();

    private static async Task<IResult> HandleAsync(
        ClaimsPrincipal user,
        IReportHandler handler)
    {
        var request = new GetIncomesByCategoryRequest
        {
            UserId = user.Identity?.Name ?? string.Empty
        };
        var result = await handler.GetIncomesByCategoryReportAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}