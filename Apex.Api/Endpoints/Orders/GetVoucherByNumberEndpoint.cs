using Apex.Api.Common.Api;
using Apex.Core.Handlers;
using Apex.Core.Models;
using Apex.Core.Requests.Orders;
using Apex.Core.Responses;

namespace Apex.Api.Endpoints.Orders;

public class GetVoucherByNumberEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{number}", HandleAsync)
            .WithName("Voucher: Get By Number")
            .WithSummary("Recupera um voucher")
            .WithDescription("Recupera um voucher")
            .WithOrder(1)
            .Produces<Response<Voucher?>>();
    
    private static async Task<IResult> HandleAsync(
        IVoucherHandler handler,
        string number)
    {
        var request = new GetVoucherByNumberRequest
        {
            Number = number
        };

        var result = await handler.GetByNumberAsync(request);
        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}